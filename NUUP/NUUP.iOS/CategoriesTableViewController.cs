using Foundation;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIKit;

namespace NUUP.iOS
{
   public partial class CategoriesTableViewController : UITableViewController
   {
      public List<Category> Categories { get; set; }
      private DataSource dataSource;
      private SubjectsModel model;

      public CategoriesTableViewController(IntPtr handle) : base(handle)
      {
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();

         model = new SubjectsModel();

         Categories = new List<Category>();

         TableView.DataSource = dataSource = new DataSource(this);

         // Get data
         await Helper.GetDataForTableAsync(this, async () =>
         {
            Categories = await model.GetCategories();
         });
      }
      
      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         base.PrepareForSegue(segue, sender);

         if (segue.Identifier == "ShowSubjects")
         {
            var vc = (SubjectsListTableViewController)segue.DestinationViewController;
            vc.Category = Categories[TableView.IndexPathForSelectedRow.Row];
         }
      }

      class DataSource : UITableViewDataSource
      {
         private readonly CategoriesTableViewController controller;
         private static string cellIdentifier = "Cell";

         public DataSource(CategoriesTableViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);

            cell.TextLabel.Text = controller.Categories[indexPath.Row].Label;

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Categories.Count;
         }
      }
   }
}