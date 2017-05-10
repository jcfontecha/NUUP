using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class OffersModel : NUUPModel
   {
      public async Task<List<Offer>> GetOffersForSubjectAsync(Subject subject)
      {
         // Get Offers
         var offerRequest = new RecordRequest()
         {
            Path = Path.NuupOffer,
            Related = new[] { Offer.UserField, Offer.IntervalField },
            Filter = string.Format("(idSubject = {0}) and (available = 1)", subject.IdSubject),
            Limit = "20",
            Order = "creation DESC"
         };

         var offers = await service.GetResourceArrayAsync<List<Offer>>(offerRequest);

         // Set subject fields for Offers
         foreach (var offer in offers)
         {
            offer.Subject = subject;
         }

         // Set User fields for Offers
         await FillDreamFactoryUsers(offers.Select(x => x.User));

         // Set Intervals and Weekdays and stuff
         var weekdays = await cache.GetWeekdaysAsync(false);

         foreach (var offer in offers)
         {
            offer.Interval.Weekday = weekdays.Where(x => x.IdWeekday == offer.Interval.IdWeekday).First();
         }

         return offers;
      }
   }
}
