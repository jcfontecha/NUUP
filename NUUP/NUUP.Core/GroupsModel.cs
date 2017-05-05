using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class GroupsModel : NUUPModel
   {
      public async Task<List<Group>> GetGroups(int limit)
      {
         // Get Groups
         var request = new RecordRequest()
         {
            Path = Path.NuupGroup,
            Related = new[] { Group.TutorField, Group.IntervalsField },
            Limit = limit.ToString(),
            Order = "creation DESC"
         };

         var groups = await service.GetResourceArrayAsync<List<Group>>(request);

         // Set User fields for Offers
         await FillDreamFactoryUsers(groups.Select(x => x.Tutor));

         // Set intervals
         var weekdays = await cache.GetWeekdaysAsync(false);
         foreach (var group in groups)
         {
            foreach (var interval in group.Intervals)
            {
               interval.Weekday = weekdays.Where(x => x.IdWeekday == interval.IdWeekday).First();
            }
         }

         return groups;
      }
   }
}
