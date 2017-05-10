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
      private UISearchController searchController;

      public SearchResults SearchResults { get; set; }
      private SearchModel model;

      public SearchTableViewController(IntPtr handle) : base(handle)
      {
         Title = NSBundle.MainBundle.LocalizedString("Búsqueda", "Búsqueda");

         model = new SearchModel();
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
         TableView.Source = dataSource = new DataSource(this);

         TableView.RowHeight = UITableView.AutomaticDimension;
         TableView.EstimatedRowHeight = 44f;

         SearchResults = new SearchResults();

         var searchResultsController = new SearchResultsViewController();

         var searchUpdater = new SearchResultsUpdater();
         searchUpdater.UpdateSearchResults += searchResultsController.SearchAsync;

         searchController = new UISearchController(searchResultsController)
         {
            SearchResultsUpdater = searchUpdater
         };

         searchController.SearchBar.SizeToFit();
         searchController.SearchBar.SearchBarStyle = UISearchBarStyle.Minimal;
         searchController.SearchBar.Placeholder = "Búsqueda";
         searchController.SearchBar.TintColor = UIColor.White;
         searchController.SearchBar.SearchButtonClicked += OnSearchButtonClickedAsync;

         searchController.HidesNavigationBarDuringPresentation = false;

         DefinesPresentationContext = true;

         NavigationItem.TitleView = searchController.SearchBar;
      }

      private async void OnSearchButtonClickedAsync(object sender, EventArgs e)
      {
         var query = searchController.SearchBar.Text;
         searchController.Active = false;

         await Helper.GetDataForTableAsync(this, true, async () =>
         {
            SearchResults = await model.GetSearchResultsAsync(query);
         });
      }

      class SearchResultsUpdater : UISearchResultsUpdating
      {
         public event Action<string> UpdateSearchResults = delegate { };

         public override void UpdateSearchResultsForSearchController(UISearchController searchController)
         {
            UpdateSearchResults(searchController.SearchBar.Text);
         }
      }

      class DataSource : UITableViewSource
      {
         private static NSString subjectCellIdentifier = new NSString("SubjectCell");
         private static NSString resultCellIdentifier = new NSString("SearchResultCell");

         readonly SearchTableViewController controller;

         public DataSource(SearchTableViewController controller)
         {
            this.controller = controller;
         }

         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            switch (indexPath.Section)
            {
               case 0:
                  var subjectCell = tableView.DequeueReusableCell(subjectCellIdentifier, indexPath);
                  subjectCell.TextLabel.Text = controller.SearchResults.Subjects[indexPath.Row].Name;
                  return subjectCell;
               case 1:
                  var resultCell = tableView.DequeueReusableCell(resultCellIdentifier, indexPath) as SearchResultTableViewCell;
                  resultCell.UpdateCell(controller.SearchResults.Offers[indexPath.Row]);
                  return resultCell;
               case 2:
                  var groupCell = tableView.DequeueReusableCell(resultCellIdentifier, indexPath) as SearchResultTableViewCell;
                  groupCell.UpdateCell(controller.SearchResults.Groups[indexPath.Row]);
                  return groupCell;
               default:
                  throw new ArgumentException("Invalid index Path");
            }
         }

         //public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
         //{
         //   if (indexPath.Section == 1 || indexPath.Section == 2)
         //   {
         //      return 135;
         //   }
         //   else
         //   {
         //      return 44;
         //   }
         //}

         public override nint RowsInSection(UITableView tableView, nint section)
         {
            switch (section)
            {
               case 0:
                  return controller.SearchResults.Subjects.Count;
               case 1:
                  return controller.SearchResults.Offers.Count;
               case 2:
                  return controller.SearchResults.Groups.Count;
               default:
                  return 0;
            }
         }

         public override nint NumberOfSections(UITableView tableView)
         {
            return 3;
         }

         public override string TitleForHeader(UITableView tableView, nint section)
         {
            switch (section)
            {
               case 0:
                  return "Materias";
               case 1:
                  return "Ofertas";
               case 2:
                  return "Grupos";
               default:
                  throw new ArgumentException("Invalid section");
            }
         }
      }
   }
}