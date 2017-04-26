using Foundation;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using UIKit;

namespace NUUP.iOS
{
   public partial class SearchTableViewController : UITableViewController
   {
      private DataSource dataSource;
      public List<IEntity> Results { get; private set; }
      private UISearchController searchController;

      public List<Subject> Materias { get; set; }
      public List<Offer> Ofertas { get; set; }
      public List<Group> Grupos { get; set; }

      public SearchTableViewController(IntPtr handle) : base(handle)
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

         var searchResultsController = new SearchResultsViewController();

         var searchUpdater = new SearchResultsUpdater();
         searchUpdater.UpdateSearchResults += searchResultsController.Search;


         searchController = new UISearchController(searchResultsController)
         {
            SearchResultsUpdater = searchUpdater
         };

         searchController.SearchBar.SizeToFit();
         searchController.SearchBar.SearchBarStyle = UISearchBarStyle.Minimal;
         searchController.SearchBar.Placeholder = "Búsqueda";
         searchController.SearchBar.TintColor = UIColor.White;

         searchController.HidesNavigationBarDuringPresentation = false;

         DefinesPresentationContext = true;

         NavigationItem.TitleView = searchController.SearchBar;
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
         readonly SearchTableViewController controller;

         public DataSource(SearchTableViewController controller)
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