using NUUP.Core;
using System;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Auth;
using SafariServices;
using Foundation;
using NUUP.Core.Model;

namespace NUUP.iOS
{
   public partial class LoginViewController : UIViewController
   {
      public UILabel LoginLabel { get; set; }
      public UITextField EmailField { get; set; }
      public UITextField PasswordField { get; set; }
      public UIButton LoginButton { get; set; }
      
      private Uri url;
      private SFSafariViewController safariVC;

      private LoginModel model;

      public LoginViewController() : base()
      {
      }

      public LoginViewController(IntPtr handle) : base(handle)
      {
         Title = "Login";
         model = new LoginModel();
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();
         
         FacebookLoginButton.TouchUpInside += StartFacebookLogin;
      }

      public void FinishLogin(string urlQuery)
      {
         safariVC.DismissViewController(true, null);

         model.FacebookLoginToDreamfactoryAsync(urlQuery);
      }

      private async void StartFacebookLogin(object sender, EventArgs e)
      {
         url = await model.GetFacebookLoginURL();
         
         ResultLabel.Text = url.ToString();

         safariVC = new SFSafariViewController(new NSUrl(url.ToString()));
         PresentViewController(safariVC, true, null);
      }
   }
}