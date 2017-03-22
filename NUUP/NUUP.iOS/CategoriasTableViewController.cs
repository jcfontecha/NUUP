using Foundation;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace NUUP.iOS
{
   public partial class CategoriasTableViewController : UITableViewController
   {
      public List<Category> Categorias { get; set; }
      private DataSource dataSource;
      private DataAccess dataAccess;

      public CategoriasTableViewController(IntPtr handle) : base(handle)
      {
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();

         dataAccess = new DataAccess();

         Categorias = new List<Category>();
         Categorias.Add(new Category() { IdCategory = 1, Label = "Humanidades" });
         Categorias.Add(new Category() { IdCategory = 2, Label = "Matemáticas" });
         Categorias.Add(new Category() { IdCategory = 3, Label = "Derecho" });

         TableView.DataSource = dataSource = new DataSource(this);

         await GetDataAsync();
      }

      private async Task GetDataAsync()
      {
         TableView.RefreshControl = new UIRefreshControl();
         TableView.RefreshControl.BeginRefreshing();
         TableView.SetContentOffset(new CoreGraphics.CGPoint(0, -TableView.RefreshControl.Frame.Size.Height), true);

         Categorias = await dataAccess.GetCategorias();

         TableView.SetContentOffset(new CoreGraphics.CGPoint(0, TableView.RefreshControl.Frame.Size.Height), true);
         TableView.RefreshControl.EndRefreshing();

         TableView.ReloadData();
      }

      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         base.PrepareForSegue(segue, sender);

         if (segue.Identifier == "showClases")
         {
            var vc = (ClasesListTableViewController)segue.DestinationViewController;
            vc.Categoria = Categorias[TableView.IndexPathForSelectedRow.Row];
         }
      }

      class DataSource : UITableViewDataSource
      {
         private readonly CategoriasTableViewController controller;
         private static string cellIdentifier = "Cell";

         public DataSource(CategoriasTableViewController controller)
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