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
      /// <summary>
      /// Helper method that animates a UI Refresh Control for the given tableView
      /// and asynchronously runs some data pulling
      /// </summary>
      /// <param name="sender">UITableViewController to be animated</param>
      /// <param name="dataUpdater">Action that synchronously gets data for the table view</param>
      /// <returns></returns>
      public static async Task GetDataForTableAsync(UITableViewController sender, Func<Task> dataUpdater)
      {
         await GetDataForTableAsync(sender, false, dataUpdater);
      }

      /// <summary>
      /// Helper method that animates a UI Refresh Control for the given UITableViewController's table
      /// and asynchronously runs some data pulling
      /// </summary>
      /// <param name="sender">UITableViewController to be animated</param>
      /// <param name="dataUpdater">Action that synchronously gets data for the table view</param>
      /// <param name="animateRefreshControl">Wether or not we should animate a RefreshControl</param>
      /// <returns></returns>
      public static async Task GetDataForTableAsync(UITableViewController sender, bool animateRefreshControl, Func<Task> dataUpdater)
      {
         // Check for animation
         if (animateRefreshControl)
         {
            sender.TableView.RefreshControl = new UIRefreshControl();
            sender.TableView.RefreshControl.BeginRefreshing();
            sender.TableView.SetContentOffset(new CGPoint(0, -sender.TableView.RefreshControl.Frame.Size.Height), true);
         }

         await GetDataAsync(sender, dataUpdater);

         if (animateRefreshControl)
         {
            sender.TableView.SetContentOffset(new CGPoint(0, sender.TableView.RefreshControl.Frame.Size.Height), true);
            sender.TableView.RefreshControl.EndRefreshing();
         }

         sender.TableView.ReloadData();
      }

      public static async Task GetDataAsync(UIViewController sender, Func<Task> dataUpdater)
      {
         // Call data pulling
         try
         {
            await dataUpdater();
         }
         catch (Exception e)
         {
            HandleServerError(sender, e);
         }
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

         ShowAlert(sender, title, message);
      }
      
      public static void HandleLoginFailureUI(UIViewController sender)
      {
         string title = "Error al iniciar sesión";
         string message = "Inténtalo de nuevo más tarde";

         ShowAlert(sender, title, message);
      }

      public static void HandleServerError(UIViewController sender, Exception e)
      {
         if (e is ServerErrorException)
         {
            ShowAlert(sender, "Error", "Hubo un error en la comunicación con el servidor. Inténtalo más tarde");
         }
         else
         {
            throw e;
         }
      }

      public static void ShowAlert(UIViewController sender, string title, string message)
      {
         var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
         alertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
         sender.PresentViewController(alertController, true, null);
      }
   }
}
