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
   public partial class NewsTableViewController : UITableViewController
   {
      private DataSource dataSource;
      private NewsModel model;
      private SessionHelper sessionHelper;

      public List<Post> Noticias { get; private set; }

      public NewsTableViewController(IntPtr handle) : base(handle)
      {
         Title = NSBundle.MainBundle.LocalizedString("Noticias", "Noticias");
      }

      public override void DidReceiveMemoryWarning()
      {
         base.DidReceiveMemoryWarning();

         // Release any cached data, images, etc that aren't in use.
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();
         NavigationController.NavigationBar.BarStyle = UIBarStyle.BlackOpaque;
         TableView.DataSource = dataSource = new DataSource(this);

         model = new NewsModel();
         Noticias = new List<Post>();

         sessionHelper = new SessionHelper(this);

         if (sessionHelper.IsLoggedIn)
         {
            sessionHelper.LoadLoggedInUser();
            await GetDataAsync();
         }
         else
         {
            sessionHelper.Login();
            sessionHelper.LoginSuccess += OnLoginSuccess;
         }
      }

      private async void OnLoginSuccess(object sender, EventArgs e)
      {
         await GetDataAsync();
      }

      public override void ViewWillAppear(bool animated)
      {
         base.ViewWillAppear(animated);

         TableView.RowHeight = UITableView.AutomaticDimension;
         TableView.EstimatedRowHeight = 150f;
         TableView.ReloadData();
      }

      public async Task GetDataAsync()
      {
         await Helper.GetDataForTableAsync(this, true, async () =>
         {
            Noticias = await model.GetLatestNewsAsync(10);
         });
      }

      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         base.PrepareForSegue(segue, sender);

         if (segue.Identifier == "VerPerfilSegue")
         {
            var vc = (ProfileTableViewController)segue.DestinationViewController;
            var senderButton = (UIButton)sender;
            CGPoint buttonPosition = senderButton.ConvertPointToView(new CGPoint(0.0f, 0.0f), TableView);
            NSIndexPath indexPath = TableView.IndexPathForRowAtPoint(buttonPosition);

            vc.User = Noticias[indexPath.Row].User;
         }
         else if (segue.Identifier == "EnviarMensajeSegue")
         {
            segue.DestinationViewController.HidesBottomBarWhenPushed = true;
         }
      }

      class DataSource : UITableViewDataSource
      {
         static readonly NSString CellIdentifier = new NSString("PostTableViewCell");
         readonly NewsTableViewController controller;

         public DataSource(NewsTableViewController controller)
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