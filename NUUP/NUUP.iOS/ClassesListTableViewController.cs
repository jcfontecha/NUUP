using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using NUUP.Core;
using NUUP.Core.Model;
using System.Threading.Tasks;

namespace NUUP.iOS
{
   public partial class ClassesListTableViewController : UITableViewController
   {
      public Category Category { get; set; }
      private ClassesListDataSource dataSource;
      public List<Subject> Classes { get; set; }
      private ClassesModel model;

      public ClassesListTableViewController(IntPtr handle) : base(handle)
      {
         Title = "Clases";
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();

         TableView.DataSource = dataSource = new ClassesListDataSource(this);
         model = new ClassesModel();

         Classes = new List<Subject>();

         await GetDataAsync();
      }

      public async Task GetDataAsync()
      {
         await Helper.GetDataAsync(TableView, () =>
         {
            Classes = model.GetSubjectsForCategory(Category).Result;
         });
      }

      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         base.PrepareForSegue(segue, sender);

         if (segue.Identifier == "showOfertas")
         {
            var vc = (OffersListTableViewController)segue.DestinationViewController;
            vc.Subject = Classes[TableView.IndexPathForSelectedRow.Row];
         }
      }

      private class ClassesListDataSource : UITableViewDataSource
      {
         readonly ClassesListTableViewController controller;
         static string cellIdentifier = "Cell";

         public ClassesListDataSource(ClassesListTableViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);
            cell.TextLabel.Text = controller.Classes[indexPath.Row].Name;

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Classes.Count;
         }
      }
   }
}