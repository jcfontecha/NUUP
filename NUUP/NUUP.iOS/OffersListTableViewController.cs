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
      public List<Offer> Offers { get; set; }
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

         TableView.RowHeight = UITableView.AutomaticDimension;
         TableView.EstimatedRowHeight = 125;

         Offers = new List<Offer>();

         await Helper.GetDataForTableAsync(this, true, async () =>
         {
            Offers = await model.GetOffersForSubjectAsync(Subject);
         });
      }

      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         base.PrepareForSegue(segue, sender);

         if (segue.Identifier == "ShowOfferDetails")
         {
            var destVC = segue.DestinationViewController as OfferDetailTableViewController;
            destVC.Offer = Offers[TableView.IndexPathForSelectedRow.Row];
         }
      }

      private class OfertasListDataSource : UITableViewDataSource
      {
         readonly OffersListTableViewController controller;
         static string cellIdentifier = "OfferCell";

         public OfertasListDataSource(OffersListTableViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath) as SearchResultTableViewCell;
            var offer = controller.Offers[indexPath.Row];

            cell.UpdateCell(offer);

            return cell;
         }

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            return controller.Offers.Count;
         }
      }
   }
}