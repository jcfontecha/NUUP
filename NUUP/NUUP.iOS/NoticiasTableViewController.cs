using Foundation;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using CoreGraphics;

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
         await Helper.GetDataAsync(TableView, () => Noticias = dataAccess.GetLatestNewsAsync(10).Result);
      }

      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         base.PrepareForSegue(segue, sender);

         if (segue.Identifier == "VerPerfilSegue")
         {
            var vc = (PerfilAjenoTableViewController)segue.DestinationViewController;
            var senderButton = (UIButton)sender;
            CGPoint buttonPosition = senderButton.ConvertPointToView(new CGPoint(0.0f, 0.0f), TableView);
            NSIndexPath indexPath = TableView.IndexPathForRowAtPoint(buttonPosition);

            vc.User = Noticias[indexPath.Row].User;
         }
      }

      class DataSource : UITableViewDataSource
      {
         static readonly NSString CellIdentifier = new NSString("PostTableViewCell");
         readonly NoticiasTableViewController controller;

         public DataSource(NoticiasTableViewController controller)
         {
            this.controller = controller;
         }
         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = (PostTableViewCell)tableView.DequeueReusableCell(CellIdentifier, indexPath);
            cell.Author = controller.Noticias[indexPath.Row].User.FirstName + " " + controller.Noticias[indexPath.Row].User.LastName;
            cell.Post = controller.Noticias[indexPath.Row].Text;

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