using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIKit;

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
   }
}
