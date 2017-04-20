using NUUP.Core;
using System;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Auth;
using SafariServices;
using Foundation;

namespace NUUP.iOS
{
   public partial class LoginViewController : UIViewController
   {
      public UILabel LoginLabel { get; set; }
      public UITextField EmailField { get; set; }
      public UITextField PasswordField { get; set; }
      public UIButton LoginButton { get; set; }

      private DataAccess dataAccess;
      private Uri url;
      private SFSafariViewController safariVC;

      public LoginViewController(IntPtr handle) : base(handle)
      {
         Title = "Login";

         dataAccess = new DataAccess();
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();

         FacebookLoginButton.TouchUpInside += StartFacebookLogin;

         

         //auth = new OAuth2Authenticator("1574089662606283", "email", url, new Uri("http://ec2-35-163-58-56.us-west-2.compute.amazonaws.com/?service=facebook"));
      }

      public async void LoginSucceeded(string urlQuery)
      {
         safariVC.DismissViewController(true, null);

         await dataAccess.FacebookLoginToDreamfactory(urlQuery);
      }

      private async void StartFacebookLogin(object sender, EventArgs e)
      {
         url = await dataAccess.GetFacebookLoginURL();

         ResultLabel.Text = url.ToString();

         safariVC = new SFSafariViewController(new NSUrl(url.ToString()));
         PresentViewController(safariVC, true, null);
      }
   }
}