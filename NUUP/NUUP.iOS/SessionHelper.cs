using Foundation;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace NUUP.iOS
{
   public class SessionHelper
   {
      public static string IsLoggedInKey { get; } = "isLoggedIn";
      public static string SessionTokenKey { get; } = "sessionToken";
      public static string UserIdKey { get; } = "userId";

      public UIViewController Sender { get; set; }

      public event EventHandler LoginSuccess;

      public bool IsLoggedIn
      {
         get
         {
            var defaults = NSUserDefaults.StandardUserDefaults;
            return defaults.BoolForKey(IsLoggedInKey);
         }
      }

      public SessionHelper(UIViewController sender)
      {
         Sender = sender;
      }

      public void Login()
      {
         var sessionManager = SessionManager.Instance;
         sessionManager.LoginSuccess += OnLoginSuccess;

         var loginVC = UIStoryboard.FromName("Main", null).InstantiateViewController("loginNavigationController");
         Sender.PresentModalViewController(loginVC, true);
      }

      private void OnLoginSuccess(object sender, LoginSuccessEventArgs e)
      {
         Sender.DismissModalViewController(true);
         SaveLoggedInUser(e.User.IdUser, e.SessionToken);

         var sessionManager = SessionManager.Instance;
         sessionManager.LoginSuccess -= OnLoginSuccess;

         string title = "Sesión iniciada";
         string message = "Bienvenido, " + e.User.DisplayName;
         var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
         alertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

         Sender.PresentViewController(alertController, true, null);

         OnLoginSuccess(new EventArgs());
      }

      public void SaveLoggedInUser(int idUser, string sessionToken)
      {
         var defaults = NSUserDefaults.StandardUserDefaults;

         defaults.SetBool(true, IsLoggedInKey);
         defaults.SetString(idUser.ToString(), UserIdKey);
         defaults.SetString(sessionToken, SessionTokenKey);
      }

      public Tuple<string, int> LoadLoggedInUser()
      {
         var defaults = NSUserDefaults.StandardUserDefaults;

         if (IsLoggedIn)
         {
            string sessionToken = defaults.StringForKey(SessionTokenKey);
            int idUser = int.Parse(defaults.StringForKey(UserIdKey));

            // TODO: Implement cache or figure out a way to fetch the data
            // or verify the login with the server in this step
            var session = SessionManager.Instance;
            Helper.GetDataAsync(Sender, async () =>
            {
               session.SetLoginInfoAsync(new User() { IdUser = idUser }, sessionToken);
            });

            return new Tuple<string, int>(sessionToken, idUser);
         }
         else
         {
            return null;
         }
      }

      protected virtual void OnLoginSuccess(EventArgs e)
      {
         LoginSuccess?.Invoke(this, e);
      }

   }
}
