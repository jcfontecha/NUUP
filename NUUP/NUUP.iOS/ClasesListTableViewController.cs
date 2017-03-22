using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using NUUP.Core;
using NUUP.Core.Model;
using System.Threading.Tasks;

namespace NUUP.iOS
{
   public partial class ClasesListTableViewController : UITableViewController
   {
      public Category Categoria { get; set; }
      private ClasesListDataSource dataSource;
      public List<Subject> Clases { get; set; }
      private DataAccess dataAccess;

      public ClasesListTableViewController(IntPtr handle) : base(handle)
      {
         Title = "Clases";
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();

         TableView.DataSource = dataSource = new ClasesListDataSource(this);
         dataAccess = new DataAccess();

         Clases = new List<Subject>();

         if (Categoria == null)
         {
            Categoria = new Category() { IdCategory = 3, Label = "Matematicas" };
         }

         await GetDataAsync();
      }

      public async Task GetDataAsync()
      {
         TableView.RefreshControl = new UIRefreshControl();
         TableView.RefreshControl.BeginRefreshing();
         TableView.SetContentOffset(new CoreGraphics.CGPoint(0, -TableView.RefreshControl.Frame.Size.Height), true);

         Clases = await dataAccess.GetClasesForCategoriaAsync(Categoria);

         TableView.SetContentOffset(new CoreGraphics.CGPoint(0, TableView.RefreshControl.Frame.Size.Height), true);
         TableView.RefreshControl.EndRefreshing();

         TableView.ReloadData();
      }

      private class ClasesListDataSource : UITableViewDataSource
      {
         readonly ClasesListTableViewController controller;
         static string cellIdentifier = "Cell";

         public ClasesListDataSource(ClasesListTableViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);
            cell.TextLabel.Text = controller.Clases[indexPath.Row].Name;

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Clases.Count;
         }
      }
   }
}