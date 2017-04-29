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
         var request = new RecordRequest()
         {
            Path = Path.NuupOffer,
            Filter = "idSubject = " + subject.IdSubject
         };

         var offersObject = await service.GetResourceAsync(request);
         var offersArray = DFHelper.ExtractResource(offersObject);
         var offers = offersArray.ToObject<List<Offer>>();

         return offers;
      }
   }
}
