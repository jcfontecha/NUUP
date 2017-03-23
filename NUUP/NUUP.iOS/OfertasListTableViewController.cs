using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using NUUP.Core.Model;

namespace NUUP.iOS
{
   public partial class OfertasListTableViewController : UITableViewController
   {
      private OfertasListDataSource dataSource;
      public List<Offer> Ofertas { get; set; }

      public OfertasListTableViewController(IntPtr handle) : base(handle)
      {
         Title = "Ofertas de clase";
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         TableView.DataSource = dataSource = new OfertasListDataSource(this);

         Ofertas = new List<Offer>();
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
            cell.TextLabel.Text = controller.Ofertas[indexPath.Row].Description;
            cell.DetailTextLabel.Text = controller.Ofertas[indexPath.Row].User.Nombre + " " + controller.Ofertas[indexPath.Row].User.Apellido;

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Ofertas.Count;
         }
      }
   }
}