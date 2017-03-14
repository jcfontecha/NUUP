using Foundation;
using NUUP.Core.Model;
using System;
using UIKit;

namespace NUUP.iOS
{
    public partial class PerfilPropioTableViewController : UITableViewController
    {
        private DataSource dataSource;
        public User Usuario { get; private set; }

        public PerfilPropioTableViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Perfil Propio", "Perfil Propio");
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
            Usuario = new User();
        }

        class DataSource : UITableViewDataSource
        {
            readonly PerfilPropioTableViewController controller;

            public DataSource(PerfilPropioTableViewController controller)
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