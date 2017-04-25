using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class LoginModel : NUUPModel
   {
      public LoginModel() : base() { }

      public async Task<Uri> GetFacebookLoginURL()
      {
         var request = new RecordRequest(Path.UserSession);

         // This is slightly unclear
         service.AddHeader(DFHelper.AvoidRedirectHeader.Item1, DFHelper.AvoidRedirectHeader.Item1);
         var jObject = await service.PostResourceAsync(request, DFHelper.FacebookRequestString);
         service.RemoveHeader(DFHelper.AvoidRedirectHeader.Item1);

         var url = jObject["response"]["url"].ToString();

         return new Uri(url);
      }

      public async Task<User> FacebookLoginToDreamfactoryAsync(string urlQuery)
      {
         // Returns string in the format of ?oauth_callback=true&<urlQuery>...
         var parameters = DFHelper.FormatFacebookCallbackRequest(urlQuery);

         var request = new RecordRequest()
         {
            Path = Path.UserSession,
            CustomQuery = parameters
         };

         var jObject = await service.PostResourceAsync(request, null);

         User user = null;
         try
         {
            user = new User()
            {
               IdDreamfactory = int.Parse(jObject["id"].ToString()),
               FirstName = jObject["first_name"].ToString(),
               LastName = jObject["last_name"].ToString(),
               DisplayName = jObject["name"].ToString(),
               Email = jObject["email"].ToString()
            };

            // Register newly logged in user with ServiceManager
            SaveLogin(user, jObject["session_token"].ToString());

            // If necessary, add the user to the NUUP Database
            await AddDreamFactoryUsertoNUUPDB(user.IdDreamfactory);
         }
         catch (Exception)
         {
            FailLogin("Hubo un error al iniciar sesión con Facebook");
         }

         return user;
      }
   }
}
