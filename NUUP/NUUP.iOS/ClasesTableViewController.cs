using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using NUUP.Core.Models;

namespace NUUP.iOS
{
    [Register("ClasesTableViewController")]
    public class ClasesTableViewController : UITableViewController
    {
        public List<Subject> Clases { get; private set; }
        private DataSource dataSource;

        public ClasesTableViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Clases", "Clases");
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
            Clases = new List<Subject>();

            Clases.Add(new Subject() { Name = "Matematicas" });
            Clases.Add(new Subject() { Name = "Español" });
        }

        class DataSource : UITableViewDataSource
        {
            private static readonly NSString cellIdentifier = new NSString("Cell");
            readonly ClasesTableViewController controller;

            public DataSource(ClasesTableViewController controller)
            {
                this.controller = controller;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);
                cell.TextLabel.Text = controller.Clases[indexPath.Row].Name;
                return cell;
            }

            public override nint RowsInSection(UITableView tableView, nint section)
            {
                return controller.Clases.Count;
            }
        }
    }
}