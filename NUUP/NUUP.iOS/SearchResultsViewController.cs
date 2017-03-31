using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using NUUP.Core.Model;

namespace NUUP.iOS
{
   public partial class SearchResultsViewController : UITableViewController
   {
      public List<Subject> Materias { get; set; }

      public SearchResultsViewController()
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         // Perform any additional setup after loading the view, typically from a nib.

         Materias = new List<Subject>();

         TableView.DataSource = new SearchResultsDataSource(this);
      }

      public void Search(string text)
      {
         // Search API
         Materias.Add(new Subject() { Name = "Matematicas" });
         Materias.Add(new Subject() { Name = "Español" });

         TableView.ReloadData();
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

            cell.TextLabel.Text = controller.Materias[indexPath.Row].Name;

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Materias.Count;
         }
      }
   }
}