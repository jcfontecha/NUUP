using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace NUUP.iOS
{
    [Register ("NoticiasTableViewController")]
    public partial class NoticiasTableViewController : UITableViewController
    {
        private DataSource dataSource;

        public NoticiasTableViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Noticias", "Noticias");
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            TableView.DataSource = dataSource = new DataSource(this);
        }

        class DataSource : UITableViewDataSource
        {
            static readonly NSString CellIdentifier = new NSString("Cell");
            readonly NoticiasTableViewController controller;
            private int count = 1;

            public DataSource(NoticiasTableViewController controller)
            {
                this.controller = controller;
            }
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

                cell.TextLabel.Text = "Bullshit " + count++;

                return cell;
            }

            public override nint RowsInSection(UITableView tableView, nint section)
            {
                return 3;
            }

            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }
        }
    }
}