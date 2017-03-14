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
    [Register("GruposTableViewController")]
    public class GruposTableViewController : UITableViewController
    {
        private DataSource dataSource;
        public List<Group> Grupos { get; set; }

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
            Grupos = new List<Group>();

            Grupos.Add(new Group() { Description = "Gran clase maestra" });
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
                cell.TextLabel.Text = controller.Grupos[indexPath.Row].Description;
                return cell;
            }

            public override nint RowsInSection(UITableView tableView, nint section)
            {
                return controller.Grupos.Count;
            }
        }
    }
}