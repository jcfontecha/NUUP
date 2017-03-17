using Foundation;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace NUUP.iOS
{
   public partial class NoticiasTableViewController : UITableViewController
   {
      private DataSource dataSource;
      private DataAccess dataAccess;
      public List<Post> Noticias { get; private set; }

      public NoticiasTableViewController(IntPtr handle) : base(handle)
      {
         Title = NSBundle.MainBundle.LocalizedString("Noticias", "Noticias");
      }

      public override void DidReceiveMemoryWarning()
      {
         base.DidReceiveMemoryWarning();

         // Release any cached data, images, etc that aren't in use.
      }

      public async override void ViewDidLoad()
      {
         base.ViewDidLoad();
         NavigationController.NavigationBar.BarStyle = UIBarStyle.BlackOpaque;

         // Perform any additional setup after loading the view, typically from a nib.

         dataAccess = new DataAccess();
         Noticias = new List<Post>();

         TableView.DataSource = dataSource = new DataSource(this);

         await GetDataAsync();
      }

      public async Task GetDataAsync()
      {
         TableView.RefreshControl = new UIRefreshControl();
         TableView.RefreshControl.BeginRefreshing();
         TableView.SetContentOffset(new CoreGraphics.CGPoint(0, -TableView.RefreshControl.Frame.Size.Height), true);

         Noticias = await dataAccess.GetLatestNews();

         TableView.SetContentOffset(new CoreGraphics.CGPoint(0, TableView.RefreshControl.Frame.Size.Height), true);
         TableView.RefreshControl.EndRefreshing();

         TableView.ReloadData();
      }

      class DataSource : UITableViewDataSource
      {
         static readonly NSString CellIdentifier = new NSString("Cell");
         readonly NoticiasTableViewController controller;

         public DataSource(NoticiasTableViewController controller)
         {
            this.controller = controller;
         }
         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

            cell.TextLabel.Text = controller.Noticias[indexPath.Row].Text;

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Noticias.Count;
         }

         public override nint NumberOfSections(UITableView tableView)
         {
            return 1;
         }
      }
   }
}