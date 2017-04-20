﻿using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using System.Web;

namespace NUUP.iOS
{
   public class Helper
   {
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
   }
}
