using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using NUUP.Core.Model;
using System.Threading.Tasks;
using NUUP.Core;

namespace NUUP.iOS
{
   public partial class OfertasListTableViewController : UITableViewController
   {
      private OfertasListDataSource dataSource;
      public Subject Clase { get; set; }
      public List<Offer> Ofertas { get; set; }
      private DataAccess dataAccess;

      public OfertasListTableViewController(IntPtr handle) : base(handle)
      {
         Title = "Ofertas de clase";
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();

         dataAccess = new DataAccess();
         TableView.DataSource = dataSource = new OfertasListDataSource(this);

         Ofertas = new List<Offer>();

         if (Clase == null)
         {
            Clase = new Subject()
            {
               IdSubject = 3,
               Name = "Algebra lineal"
            };
         }

         await GetDataAsync();
      }

      private async Task GetDataAsync()
      {
         TableView.RefreshControl = new UIRefreshControl();
         TableView.RefreshControl.BeginRefreshing();
         TableView.SetContentOffset(new CoreGraphics.CGPoint(0, -TableView.RefreshControl.Frame.Size.Height), true);

         Ofertas = await dataAccess.GetOfertasForSubjectAsync(Clase);

         TableView.SetContentOffset(new CoreGraphics.CGPoint(0, TableView.RefreshControl.Frame.Size.Height), true);
         TableView.RefreshControl.EndRefreshing();

         TableView.ReloadData();
      }

      private class OfertasListDataSource : UITableViewDataSource
      {
         readonly OfertasListTableViewController controller;
         static string cellIdentifier = "Cell";

         public OfertasListDataSource(OfertasListTableViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);
            cell.TextLabel.Text = controller.Ofertas[indexPath.Row].Subject.Name;
            cell.DetailTextLabel.Text = controller.Ofertas[indexPath.Row].Description;

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Ofertas.Count;
         }
      }
   }
}