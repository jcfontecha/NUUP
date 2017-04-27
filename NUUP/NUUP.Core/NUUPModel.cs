using Newtonsoft.Json;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public abstract class NUUPModel
   {
      protected ServiceManager service;

      public NUUPModel()
      {
         service = ServiceManager.Instance;
      }

      protected async Task AddDreamFactoryUsertoNUUPDB(int id)
      {
         // Check if we already have a user with that DF ID in the NUUP DB
         var json = await service.GetResourceJSONAsync(new RecordRequest()
         {
            Path = Path.NuupUser,
            Filter = "idDreamfactory = " + id,
            CountOnly = true
         });

         // If not, create one
         if (json == "0")
         {
            var postJson = DFHelper.WrapInResourceTag("{\"idDreamfactory\": " + id + "}");
            await service.PostResourceAsync(new RecordRequest(Path.NuupUser), postJson);
         }
      }

      /// <summary>
      /// Completes DreamFactory info (FirstName, LastName and email)
      /// </summary>
      /// <param name="users">Set of NUUP users to be filled</param>
      /// <returns></returns>
      public async Task FillDreamFactoryUsers(IEnumerable<User> users)
      {
         var request = new RecordRequest()
         {
            Path = Path.SystemUser,
            Fields = new[] { "id", "name", "first_name", "last_name", "email" },
            Ids = users.Select(x => x.IdDreamfactory)
         };

         var jObject = await service.GetResourceAsync(request);

         DFHelper.ExtractResource(jObject, (newUser) =>
         {
            foreach (var user in users)
            {
               if (user.IdDreamfactory == (int)newUser.GetValue("id"))
               {
                  user.DisplayName = newUser.GetValue("name").ToString();
                  user.FirstName = newUser.GetValue("first_name").ToString();
                  user.LastName = newUser.GetValue("last_name").ToString();
                  user.Email = newUser.GetValue("email").ToString();
               }
            }
         });
      }

      /// <summary>
      /// Completes DreamFactory info (FirstName, LastName and email)
      /// </summary>
      /// <param name="user"></param>
      /// <returns></returns>
      public async Task FillDreamFactoryUser(User user)
      {
         var request = new RecordRequest()
         {
            Path = Path.SystemUser,
            Id = user.IdUser,
            Fields = new[] { "first_name", "last_name", "email" }
         };

         var jObject = await service.GetResourceAsync(request);

         user.FirstName = jObject["first_name"].ToString();
         user.LastName = jObject["last_name"].ToString();
         user.Email = jObject["email"].ToString();
      }

      /// <summary>
      /// Returns a full user given it's id
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public async Task<User> GetFullUserAsync(int id)
      {
         var request = new RecordRequest()
         {
            Path = Path.NuupUser,
            Id = id,
            Related = new[] { "degree_by_idDegree" }
         };

         var user = await service.GetResourceAsync<User>(request);

         await FillDreamFactoryUser(user);

         return user;
      }

   }
}
