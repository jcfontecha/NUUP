using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace NUUP.iOS
{
    [Register("DetalleClaseTableViewController")]
    public class DetalleClaseTableViewController : UITableViewController
    {
        public DetalleClaseTableViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Detalle clase", "Detalle clase");
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
        }
    }
}