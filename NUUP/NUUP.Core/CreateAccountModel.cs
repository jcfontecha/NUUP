using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class CreateAccountModel : NUUPModel
   {
      public CreateAccountModel() : base()
      {

      }

      public async Task<bool> SendNUUPRegistration(string firstName, string lastName, string email)
      {
         var request = new RecordRequest()
         {
            Path = Path.UserRegister
         };

         dynamic json = new JObject();
         json.email = email;
         json.first_name = firstName;
         json.last_name = lastName;
         json.display_name = firstName + " " + lastName;

         try
         {
            var jObject = await service.PostResourceAsync(request, json.ToString());
            return true;
         }
         catch (Exception)
         {
            throw new Exception("Hubo un error al registrar al usuario. Inténtalo más tarde");
         }

      }
   }
}
