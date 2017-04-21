using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUUP.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NUUP.Core
{
   public class DataAccess
   {
      private ServiceManager service;
      public User LoggedInUser { get; set; }

      // Cache properties
      private List<Category> categoriesCache;
      private List<Degree> degreesCache;
      private List<Subject> subjectsCache;

      public DataAccess()
      {
         service = ServiceManager.Instance;

         categoriesCache = new List<Category>();
         degreesCache = new List<Degree>();
         subjectsCache = new List<Subject>();
      }

      public async Task<Uri> GetFacebookLoginURL()
      {
         var url = await service.PostResourceForRedirectAsync("user/session", DFHelper.FacebookRequestString);

         return new Uri(url);
      }

      public async Task<string> FacebookLoginToDreamfactory(string urlQuery)
      {
         // Returns string in the format of ?oauth_callback=true&<urlQuery>...
         var parameters = DFHelper.FormatFacebookCallbackRequest(urlQuery);

         var json = await service.PostResourceWithParametersAsync("user/session", parameters);
         var jObject = JObject.Parse(json);
         
         // Get the ID of the logged in user
         var id = jObject.GetValue("id").ToString();

         // If necessary, add the user to the NUUP Database
         await AddDreamFactoryUsertoNUUPDB((int)jObject.GetValue("id"));

         return json;
      }

      private async Task AddDreamFactoryUsertoNUUPDB(int id)
      {
         // Check if we already have a user with that DF ID in the NUUP DB
         var json2 = await GetRecords(new RecordRequest()
         {
            Path = "user",
            Filter = "idDreamfactory = " + id,
            CountOnly = true
         });

         // If not, create one
         if (json2 == "0")
         {
            var postJson = DFHelper.WrapInResourceTag("{\"idDreamfactory\": " + id + "}");
            await service.PostResourceAsync(DFHelper.userTable, postJson);
         }
      }

      public async Task<string> GetRecords(RecordRequest request)
      {
         var url = request.ToString();
         var json = await service.GetResourceAsync(url);

         return json;
      }

      /// <summary>
      /// Retreives a specified User
      /// </summary>
      /// <param name="id">Id of the user to be retreived</param>
      /// <returns></returns>
      public async Task<User> GetUserAsync(int id)
      {
         var json = await service.GetResourceAsync("nuup/_table/user/1");
         var user = JsonConvert.DeserializeObject<User>(json);

         return user;
      }

      public async Task<User> GetFullUserAsync(int id)
      {
         var request = new RecordRequest() {
            Id = id,
            Related = new [] { "degree_by_idDegree" }
         };

         var json = await service.GetResourceAsync(request.ToString());
         var user = JsonConvert.DeserializeObject<User>(json);

         await FillDreamFactoryUser(user);

         return user;
      }

      public async Task CompleteSingleUserAsync(User user)
      {
         if (string.IsNullOrEmpty(user.FirstName))
         {
            await FillDreamFactoryUser(user);
         }

         if (user.Degree == null)
         {
            await FillUserDegree(user);
         }
      }

      /// <summary>
      /// Completes DreamFactory info (FirstName, LastName and email)
      /// </summary>
      /// <param name="user"></param>
      /// <returns></returns>
      public async Task FillDreamFactoryUser(User user)
      {
         var json = await service.GetResourceAsync("system/user/" + user.IdUser + "?fields=first_name%2Clast_name%2Cemail");
         var jObject = JObject.Parse(json);

         user.FirstName = jObject.GetValue("first_name").ToString();
         user.LastName = jObject.GetValue("last_name").ToString();
         user.Email = jObject.GetValue("email").ToString();
      }

      /// <summary>
      /// Fills the given User's Degree field
      /// </summary>
      /// <param name="user"></param>
      /// <returns></returns>
      private async Task FillUserDegree(User user)
      {
         if (!user.IdDegree.HasValue)
         {
            return;
         }

         Degree degree;
         if (degreesCache.Select(x => x.IdDegree).Contains(user.IdDegree.Value))
         {
            degree = degreesCache.Where(x => x.IdDegree == user.IdDegree).First();
         }
         else
         {
            var json = await service.GetResourceAsync("nuup/_table/degree/" + user.IdDegree);
            degree = JsonConvert.DeserializeObject<Degree>(json);
         }

         user.Degree = degree;
      }

      /// <summary>
      /// Completes DreamFactory info (FirstName, LastName and email)
      /// </summary>
      /// <param name="users">Set of NUUP users to be filled</param>
      /// <returns></returns>
      public async Task FillDreamFactoryUsers(IEnumerable<User> users)
      {
         // Get list of IDs to make only one HTTP request
         string ids = "";
         User last = users.Last();
         foreach (var user in users)
         {
            ids += user.IdDreamfactory;

            if (user != last)
            {
               ids += ",";
            }
         }

         var json = await service.GetResourceAsync("system/user?fields=id%2Cfirst_name%2Clast_name%2Cemail&ids=" + Uri.EscapeDataString(ids));
         ExtractResource(json, (newUser) =>
         {
            foreach (var user in users)
            {
               if (user.IdDreamfactory == (int)newUser.GetValue("id"))
               {
                  user.FirstName = newUser.GetValue("first_name").ToString();
                  user.LastName = newUser.GetValue("last_name").ToString();
                  user.Email = newUser.GetValue("email").ToString();
               }
            }
         });
      }

      /// <summary>
      /// Returns the latest number of news
      /// </summary>
      /// <param name="limit">Limit of posts to return</param>
      /// <returns></returns>
      public async Task<List<Post>> GetLatestNewsAsync(int limit)
      {
         // Get POSTS from the table in the API
         var json = await service.GetResourceAsync("nuup/_table/post?related=user_by_idUser&limit=" + limit + "&order=date%20DESC");
         var jObject = JObject.Parse(json);
         var jToken = jObject.GetValue("resource");
         List<Post> posts = jToken.ToObject<List<Post>>();

         // Get DreamFactory data for each user
         await FillDreamFactoryUsers(posts.Select(x => x.User));

         return posts;
      }

      /// <summary>
      /// Extracts the Array under the "resource" tag in the JSON string
      /// </summary>
      /// <param name="json"></param>
      /// <returns></returns>
      private JArray ExtractResource(string json)
      {
         var jObject = JObject.Parse(json);
         var jToken = jObject.GetValue("resource");
         return JArray.Parse(jToken.ToString());
      }

      /// <summary>
      /// Extracts the elements inside the "resource" tag in the JSON data.
      /// </summary>
      /// <param name="json">JSON string</param>
      /// <param name="handler">Action to handle each item</param>
      private void ExtractResource(string json, Action<JObject> handler)
      {
         var array = ExtractResource(json);

         foreach (JObject item in array)
         {
            handler(item);
         }
      }

      public async Task<List<Category>> GetCategorias()
      {
         var categorias = new List<Category>();

         await Task.Run(() =>
         {
            var categoria = new Category() { IdCategory = 1, Label = "Matematicas" };
            categorias.Add(categoria);
            var categoria2 = new Category() { IdCategory = 2, Label = "Derecho" };
            categorias.Add(categoria2);
            var categoria3 = new Category() { IdCategory = 3, Label = "Humanidades" };
            categorias.Add(categoria3);
         });

         return categorias;
      }

      public async Task<List<Subject>> GetClasesForCategoriaAsync(Category category)
      {
         var clases = new List<Subject>();

         await Task.Run(() =>
         {
            var subject = new Subject() { IdSubject = 3, Name = "Calculo", IdCategory = category.IdCategory, Category = category };
            clases.Add(subject);
            var subject2 = new Subject() { IdSubject = 4, Name = "Algebra Lineal", IdCategory = category.IdCategory, Category = category };
            clases.Add(subject2);
         });

         return clases;
      }

      public async Task<List<Offer>> GetOfertasForSubjectAsync(Subject subject)
      {
         var ofertas = new List<Offer>();

         await Task.Run(() =>
         {
            var weekday = new Weekday() { IdWeekday = 1, Label = "Lunes" };
            var interval = new Interval() { IdInterval = 1, IdWeekday = weekday.IdWeekday, Weekday = weekday };
            interval.startTime = new TimeSpan(2, 0, 0);
            interval.endTime = new TimeSpan(4, 0, 0);

            var oferta = new Offer()
            {
               IdOffer = 3,
               Description = "Clases para principiantes",
               Interval = interval,
               IdInterval = interval.IdInterval,
               Subject = subject,
               IdSubject = subject.IdSubject
            };

            ofertas.Add(oferta);

            var weekday2 = new Weekday() { IdWeekday = 2, Label = "Martes" };
            var interval2 = new Interval() { IdInterval = 2, IdWeekday = weekday2.IdWeekday, Weekday = weekday };
            interval.startTime = new TimeSpan(3, 0, 0);
            interval.endTime = new TimeSpan(5, 0, 0);

            var oferta2 = new Offer()
            {
               IdOffer = 4,
               Description = "Clases intermedias, muy efectivas",
               Interval = interval2,
               IdInterval = interval2.IdInterval,
               Subject = subject,
               IdSubject = subject.IdSubject
            };

            ofertas.Add(oferta2);
         });

         return ofertas;
      }
   }
}
