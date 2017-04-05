using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace NUUP.iOS
{
   public partial class LoginViewController : UIViewController
   {
      public UILabel LoginLabel { get; set; }
      public UITextField EmailField { get; set; }
      public UITextField PasswordField { get; set; }
      public UIButton LoginButton { get; set; }

      public LoginViewController(IntPtr handle) : base(handle)
      {
         Title = "Login";
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         
      }
   }
}