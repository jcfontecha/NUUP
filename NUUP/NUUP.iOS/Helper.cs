using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using System.Web;
using Foundation;
using NUUP.Core.Model;
using NUUP.Core;

namespace NUUP.iOS
{
   public class Helper
   {
      public static string IsLoggedInKey { get; } = "isLoggedIn";
      public static string SessionTokenKey { get; } = "sessionToken";
      public static string UserIdKey { get; } = "userId";

      /// <summary>
      /// Helper method that animates a UI Refresh Control for the given tableView
      /// and asynchronously runs some data pulling
      /// </summary>
      /// <param name="tableView">The table view to be animated</param>
      /// <param name="dataUpdater">Action that synchronously gets data for the table view</param>
      /// <returns></returns>
      public static async Task GetDataAsync(UITableView tableView, Action dataUpdater)
      {
         tableView.RefreshControl = new UIRefreshControl();
         tableView.RefreshControl.BeginRefreshing();
         tableView.SetContentOffset(new CGPoint(0, -tableView.RefreshControl.Frame.Size.Height), true);

         await Task.Run(() =>
         {
            dataUpdater();
         });

         tableView.SetContentOffset(new CGPoint(0, tableView.RefreshControl.Frame.Size.Height), true);
         tableView.RefreshControl.EndRefreshing();

         tableView.ReloadData();
      }

      public static string RemoveQueryStringByKey(string url, string key)
      {
         var uri = new Uri(url);

         // this gets all the query string key value pairs as a collection
         var newQueryString = HttpUtility.ParseQueryString(uri.Query);

         // this removes the key if exists
         newQueryString.Remove(key);

         // this gets the page path from root without QueryString
         string pagePathWithoutQueryString = uri.GetLeftPart(UriPartial.Path);

         return newQueryString.Count > 0
             ? String.Format("{0}?{1}", pagePathWithoutQueryString, newQueryString)
             : pagePathWithoutQueryString;
      }

      public static bool IsLoggedIn
      {
         get {
            var defaults = NSUserDefaults.StandardUserDefaults;
            return defaults.BoolForKey(IsLoggedInKey);
         }
      }

      public static void ShowLoginUI(UIViewController sender)
      {
         var loginVC = UIStoryboard.FromName("Main", null).InstantiateViewController("loginNavigationController");
         sender.PresentModalViewController(loginVC, true);
      }

      public static void HandleLoginSuccessUI(UIViewController sender, string name)
      {
         sender.DismissModalViewController(true);

         string title = "Sesión iniciada";
         string message = "Bienvenido, " + name;
         var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
         alertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
         sender.PresentViewController(alertController, true, null);
      }
      
      public static void HandleLoginFailureUI(UIViewController sender)
      {
         string title = "Error al iniciar sesión";
         string message = "Inténtalo de nuevo más tarde";

         var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
         alertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
         sender.PresentViewController(alertController, true, null);
      }

      public static void SaveLoggedInUser(int idUser, string sessionToken)
      {
         var defaults = NSUserDefaults.StandardUserDefaults;

         defaults.SetBool(true, IsLoggedInKey);
         defaults.SetString(idUser.ToString(), UserIdKey);
         defaults.SetString(sessionToken, SessionTokenKey);
      }

      public static Tuple<string, int> LoadLoggedInUser()
      {
         var defaults = NSUserDefaults.StandardUserDefaults;

         if (IsLoggedIn)
         {
            string sessionToken = defaults.StringForKey(SessionTokenKey);
            int idUser = int.Parse(defaults.StringForKey(UserIdKey));
            return new Tuple<string, int>(sessionToken, idUser);
         }
         else
         {
            return null;
         }
      }
   }
}
