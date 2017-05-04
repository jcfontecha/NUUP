using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using NUUP.Core.Model;
using System.Threading.Tasks;
using NUUP.Core;

namespace NUUP.iOS
{
   public partial class OffersListTableViewController : UITableViewController
   {
      private OfertasListDataSource dataSource;
      public Subject Subject { get; set; }
      public List<Offer> Ofertas { get; set; }
      private OffersModel model;

      public OffersListTableViewController(IntPtr handle) : base(handle)
      {
         Title = "Ofertas de clase";
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();

         model = new OffersModel();
         TableView.DataSource = dataSource = new OfertasListDataSource(this);

         Ofertas = new List<Offer>();

         await Helper.GetDataAsync(this, true, async () =>
         {
            Ofertas = await model.GetOffersForSubjectAsync(Subject);
         });
      }

      private class OfertasListDataSource : UITableViewDataSource
      {
         readonly OffersListTableViewController controller;
         static string cellIdentifier = "Cell";

         public OfertasListDataSource(OffersListTableViewController controller)
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