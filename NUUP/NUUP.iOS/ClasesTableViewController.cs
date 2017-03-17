using Foundation;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using UIKit;

namespace NUUP.iOS
{
   public partial class ClasesTableViewController : UITableViewController
   {
      public List<Category> Categorias { get; set; }
      private DataSource dataSource;
      private DataAccess dataAccess;

      public ClasesTableViewController(IntPtr handle) : base(handle)
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         dataAccess = new DataAccess();

         Categorias = new List<Category>();
         Categorias.Add(new Category() { IdCategory = 1, Label = "Humanidades" });
         Categorias.Add(new Category() { IdCategory = 2, Label = "Matemáticas" });
         Categorias.Add(new Category() { IdCategory = 3, Label = "Derecho" });

         TableView.DataSource = dataSource = new DataSource(this);
      }

      private async void GetData()
      {
         TableView.RefreshControl = new UIRefreshControl();
         TableView.RefreshControl.BeginRefreshing();
         TableView.SetContentOffset(new CoreGraphics.CGPoint(0, -TableView.RefreshControl.Frame.Size.Height), true);

         Categorias = await dataAccess.GetCategorias();

         TableView.SetContentOffset(new CoreGraphics.CGPoint(0, TableView.RefreshControl.Frame.Size.Height), true);
         TableView.RefreshControl.EndRefreshing();

         TableView.ReloadData();
      }

      class DataSource : UITableViewDataSource
      {
         private readonly ClasesTableViewController controller;
         private static string cellIdentifier = "Cell";

         public DataSource(ClasesTableViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);

            cell.TextLabel.Text = controller.Categorias[indexPath.Row].Label;

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Categorias.Count;
         }
      }
   }
}