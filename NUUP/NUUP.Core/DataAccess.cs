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
   }
}
