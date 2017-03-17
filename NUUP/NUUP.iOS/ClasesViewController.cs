using Foundation;
using System;
using UIKit;

namespace NUUP.iOS
{
   public partial class ClasesViewController : UIViewController
   {
      public ClasesViewController(IntPtr handle) : base(handle)
      {
         Title = NSBundle.MainBundle.LocalizedString("Clases", "Clases");
      }

      public override void DidReceiveMemoryWarning()
      {
         base.DidReceiveMemoryWarning();
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();
      }
   }
}