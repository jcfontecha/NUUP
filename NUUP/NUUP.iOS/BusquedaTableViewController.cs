using Foundation;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using UIKit;

namespace NUUP.iOS
{
   public partial class BusquedaTableViewController : UITableViewController
   {
      private DataSource dataSource;
      public List<IEntity> Results { get; private set; }

      public List<Subject> Materias { get; set; }
      public List<Offer> Ofertas { get; set; }
      public List<Group> Grupos { get; set; }

      public BusquedaTableViewController(IntPtr handle) : base(handle)
      {
         Title = NSBundle.MainBundle.LocalizedString("Búsqueda", "Búsqueda");
      }

      public override void DidReceiveMemoryWarning()
      {
         // Releases the view if it doesn't have a superview.
         base.DidReceiveMemoryWarning();

         // Release any cached data, images, etc that aren't in use.
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         // Perform any additional setup after loading the view
         TableView.DataSource = dataSource = new DataSource(this);

         Results = new List<IEntity>();
         Materias = new List<Subject>();
         Ofertas = new List<Offer>();
         Grupos = new List<Group>();

         var searchUpdater = new SearchResultsUpdater();
         searchUpdater.UpdateSearchResults += Search;

         var searchController = new UISearchController(this)
         {
            SearchResultsUpdater = searchUpdater
         };

         searchController.SearchBar.SizeToFit();
         searchController.SearchBar.SearchBarStyle = UISearchBarStyle.Minimal;
         searchController.SearchBar.Placeholder = "Búsqueda";

         searchController.HidesNavigationBarDuringPresentation = false;

         DefinesPresentationContext = true;

         NavigationItem.TitleView = searchController.SearchBar;
      }

      private void Search(string obj)
      {
         // Search API
         Materias.Add(new Subject() { Name = "Matematicas" });
         Materias.Add(new Subject() { Name = "Español" });

         TableView.ReloadData();
      }

      class SearchResultsUpdater : UISearchResultsUpdating
      {
         public event Action<string> UpdateSearchResults = delegate { };

         public override void UpdateSearchResultsForSearchController(UISearchController searchController)
         {
            UpdateSearchResults(searchController.SearchBar.Text);
         }
      }

      class DataSource : UITableViewDataSource
      {
         private static NSString cellIdentifier = new NSString("Cell");
         readonly BusquedaTableViewController controller;

         public DataSource(BusquedaTableViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);
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