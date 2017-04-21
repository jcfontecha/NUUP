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
         var jObject = await service.GetResourceAsync(new RecordRequest()
         {
            Path = Path.User,
            Filter = "idDreamfactory = " + id,
            CountOnly = true
         });

         // If not, create one
         if (jObject.ToString() == "0")
         {
            var postJson = DFHelper.WrapInResourceTag("{\"idDreamfactory\": " + id + "}");
            await service.PostResourceAsync(new RecordRequest(Path.NuupUser), postJson);
         }
      }
   }
}
