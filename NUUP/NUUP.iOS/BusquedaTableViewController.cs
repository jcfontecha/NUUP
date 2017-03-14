using Foundation;
using NUUP.Core;
using System;
using System.Collections.Generic;
using UIKit;

namespace NUUP.iOS
{
    public partial class BusquedaTableViewController : UITableViewController
    {
        private DataSource dataSource;
        public List<IEntity> Results { get; private set; }

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
                return cell;
            }

            public override nint RowsInSection(UITableView tableView, nint section)
            {
                return controller.Results.Count;
            }
        }
    }
}