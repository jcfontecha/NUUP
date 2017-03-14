using Foundation;
using NUUP.Core.Model;
using System;
using UIKit;

namespace NUUP.iOS
{
    public partial class DetalleClaseTableViewController : UITableViewController
    {
        public Offer Offer { get; set; }
        public DetalleClaseTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Offer = new Offer() { Description = "Hola viejo" };
        }
    }
}