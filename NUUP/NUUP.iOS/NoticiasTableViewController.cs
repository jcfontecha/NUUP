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
    [Register ("NoticiasTableViewController")]
    public partial class NoticiasTableViewController : UITableViewController
    {
        private DataSource dataSource;
        public List<Post> Noticias { get; private set; }

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
            Noticias = new List<Post>();

            Noticias.Add(new Post() { Text = "Hola mundo" });
            Noticias.Add(new Post() { Text = "Adios mundo" });
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

                cell.TextLabel.Text = controller.Noticias[indexPath.Row].Text;

                return cell;
            }

            public override nint RowsInSection(UITableView tableView, nint section)
            {
                return controller.Noticias.Count;
            }

            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }
        }
    }
}