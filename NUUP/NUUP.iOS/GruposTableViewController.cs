using Foundation;
using NUUP.Core;
using System;
using System.Collections.Generic;
using UIKit;

namespace NUUP.iOS
{
    public partial class GruposTableViewController : UITableViewController
    {
        private DataSource dataSource;
        public List<IEntity> Results { get; private set; }

        public GruposTableViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Grupos", "Grupos");
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
            readonly GruposTableViewController controller;

            public DataSource(GruposTableViewController controller)
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