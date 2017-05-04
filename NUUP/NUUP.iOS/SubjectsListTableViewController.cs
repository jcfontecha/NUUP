using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using NUUP.Core;
using NUUP.Core.Model;
using System.Threading.Tasks;

namespace NUUP.iOS
{
   public partial class SubjectsListTableViewController : UITableViewController
   {
      public Category Category { get; set; }
      private ClassesListDataSource dataSource;
      public List<Subject> Subjects { get; set; }
      private SubjectsModel model;

      public SubjectsListTableViewController(IntPtr handle) : base(handle)
      {
         Title = "Clases";
         model = new SubjectsModel();
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();

         TableView.DataSource = dataSource = new ClassesListDataSource(this);

         await Helper.GetDataAsync(this, true, async () =>
         {
            Subjects = await model.GetSubjectsForCategory(Category);
         });
      }

      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         base.PrepareForSegue(segue, sender);

         if (segue.Identifier == "showOfertas")
         {
            var vc = (OffersListTableViewController)segue.DestinationViewController;
            vc.Subject = Subjects[TableView.IndexPathForSelectedRow.Row];
         }
      }

      private class ClassesListDataSource : UITableViewDataSource
      {
         readonly SubjectsListTableViewController controller;
         static string cellIdentifier = "Cell";

         public ClassesListDataSource(SubjectsListTableViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);
            cell.TextLabel.Text = controller.Subjects[indexPath.Row].Name;

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Subjects.Count;
         }
      }
   }
}