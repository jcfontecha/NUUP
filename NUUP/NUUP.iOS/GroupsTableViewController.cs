using Foundation;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using UIKit;

namespace NUUP.iOS
{
   public partial class GroupsTableViewController : UITableViewController
   {
      private DataSource dataSource;
      public List<Group> Groups { get; private set; }
      private GroupsModel model;

      public GroupsTableViewController(IntPtr handle) : base(handle)
      {
         Title = NSBundle.MainBundle.LocalizedString("Grupos", "Grupos");
         model = new GroupsModel();
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();

         // Perform any additional setup after loading the view
         TableView.Source = dataSource = new DataSource(this);

         TableView.RowHeight = UITableView.AutomaticDimension;
         TableView.EstimatedRowHeight = 125;

         Groups = new List<Group>();

         await Helper.GetDataAsync(this, true, async () =>
         {
            Groups = await model.GetGroups(20);
         });
      }

      class DataSource : UITableViewSource
      {
         private static NSString cellIdentifier = new NSString("GroupCell");
         readonly GroupsTableViewController controller;

         public DataSource(GroupsTableViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath) as SearchResultTableViewCell;
            cell.UpdateCell(controller.Groups[indexPath.Row]);

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Groups.Count;
         }
      }
   }
}