using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using NUUP.Core.Model;
using NUUP.Core;

namespace NUUP.iOS
{
   public partial class SearchResultsViewController : UITableViewController
   {
      public List<Subject> Subjects { get; set; }
      private SearchModel model;

      public SearchResultsViewController()
      {
         model = new SearchModel();
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         // Perform any additional setup after loading the view, typically from a nib.

         Subjects = new List<Subject>();

         TableView.DataSource = new SearchResultsDataSource(this);
      }

      public async void SearchAsync(string text)
      {
         await Helper.GetDataForTableAsync(this, async () =>
         {
            Subjects = await model.SearchSubjectsAsync(text);
         });
      }

      class SearchResultsDataSource : UITableViewDataSource
      {
         readonly SearchResultsViewController controller;

         public SearchResultsDataSource(SearchResultsViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = new UITableViewCell();

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