using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class ProfileModel : NUUPModel
   {
      /// <summary>
      /// Fills the given User's Degree field
      /// </summary>
      /// <param name="user"></param>
      /// <returns></returns>
      protected async Task FillUserDegree(User user)
      {
         if (!user.IdDegree.HasValue)
         {
            return;
         }

         var request = new RecordRequest()
         {
            Path = Path.NuupDegree,
            Id = user.IdDegree
         };

         Degree degree;
         //if (degreesCache.Select(x => x.IdDegree).Contains(user.IdDegree.Value))
         //{
         //   degree = degreesCache.Where(x => x.IdDegree == user.IdDegree).First();
         //}
         //else
         //{
         degree = await service.GetResourceAsync<Degree>(request);
         //}

         user.Degree = degree;
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
   }
}
