using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace NUUP.iOS
{
    [Register("ClasesViewController")]
    public partial class ClasesViewController : UIViewController
    {
        public ClasesViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Clases", "Clases");
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
        }
    }
}