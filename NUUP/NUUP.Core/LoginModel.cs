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
         // Report login attempt to session manager
         var session = SessionManager.Instance;
         session.StartLogin();

         try
         {
            var request = new RecordRequest(Path.UserSession);

            service.AddHeader(DFHelper.AvoidRedirectHeader.Item1, DFHelper.AvoidRedirectHeader.Item2);
            var jObject = await service.PostResourceAsync(request, DFHelper.FacebookRequestString);
            service.RemoveHeader(DFHelper.AvoidRedirectHeader.Item1);

            var url = jObject["response"]["url"].ToString();

            return new Uri(url);
         }
         catch (Exception)
         {
            var message = "Ocurrió un problema. Intentalo más tarde";
            session.FailLogin(message);

            return null;
         }
      }

      public async Task<User> FacebookLoginToDreamfactoryAsync(string urlQuery)
      {
         try
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
            user = new User()
            {
               IdDreamfactory = int.Parse(jObject["id"].ToString()),
               FirstName = jObject["first_name"].ToString(),
               LastName = jObject["last_name"].ToString(),
               DisplayName = jObject["name"].ToString(),
               Email = jObject["email"].ToString()
            };

            // If necessary, add the user to the NUUP Database
            await AddDreamFactoryUsertoNUUPDB(user.IdDreamfactory);

            // Register newly logged in user with SessionManager
            var session = SessionManager.Instance;
            session.SetLoginInfo(user, jObject["session_token"].ToString());

            return user;
         }
         catch (Exception)
         {
            var message = "Hubo un error al iniciar sesión con Facebook. Puedes intentarlo de nuevo";
            var session = SessionManager.Instance;
            session.FailLogin(message);

            return null;
         }
      }
   }
}
