using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace NUUP.iOS
{
    [Register("GruposTableViewController")]
    public class GruposTableViewController : UITableViewController
    {
        private DataSource dataSource;

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
        }

        class DataSource : UITableViewDataSource
        {
            readonly GruposTableViewController controller;

            public DataSource(GruposTableViewController controller)
            {
                this.controller = controller;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                throw new NotImplementedException();
            }

            public override nint RowsInSection(UITableView tableView, nint section)
            {
                throw new NotImplementedException();
            }
        }
    }
}