using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class NewsModel : NUUPModel
   {
      /// <summary>
      /// Returns the latest number of news
      /// </summary>
      /// <param name="limit">Limit of posts to return</param>
      /// <returns></returns>
      public async Task<List<Post>> GetLatestNewsAsync(int limit)
      {
         // Get POSTS from the table in the API
         var request = new RecordRequest()
         {
            Path = Path.NuupPost,
            Related = new[] { "user_by_idUser" },
            Limit = limit.ToString(),
            Order = "date DESC"
         };

         var jObject = await service.GetResourceAsync(request);
         
         var jToken = jObject["resource"];
         List<Post> posts = jToken.ToObject<List<Post>>();

         // Get DreamFactory data for each user
         await FillDreamFactoryUsers(posts.Select(x => x.User));

         return posts;
      }
   }
}
