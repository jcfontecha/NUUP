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
         
         // Login button
         FacebookLoginButton.TouchUpInside += FacebookLogin;
         LoginButton.TouchUpInside += EmailLogin;

         // Facebook callback
         var session = SessionManager.Instance;
         session.FacebookCallback += OnFacebookCallback;
         session.LoginFail += OnLoginFail;

         LoadingActivityIndicatorView.Hidden = true;
      }

      private void EmailLogin(object sender, EventArgs e)
      {
         model.EmailLoginAsync(EmailTextField.Text, PasswordTextField.Text);
      }

      private void OnLoginFail(object sender, LoginFailEventArgs e)
      {
         var alertController = UIAlertController.Create("Error", e.Message, UIAlertControllerStyle.Alert);
         alertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

         PresentViewController(alertController, true, null);
      }

      private void OnFacebookCallback(object sender, FacebookCallbackEventArgs e)
      {
         DreamFactoryFacebookLogin(e.Query);
      }

      public async void DreamFactoryFacebookLogin(string facebookUrlQuery)
      {
         safariVC.DismissViewController(true, null);

         SetUIState(false);

         await model.FacebookLoginToDreamfactoryAsync(facebookUrlQuery);

         SetUIState(false);
      }

      private void SetUIState(bool enabled)
      {
         if (enabled)
         {
            LoadingActivityIndicatorView.StartAnimating();
         }
         else
         {
            LoadingActivityIndicatorView.StopAnimating();
         }

         LoadingActivityIndicatorView.Hidden = !enabled;
         CreateAccountButton.Enabled = !enabled;
         LoginButton.Enabled = !enabled;
         FacebookLoginButton.Enabled = !enabled;
      }

      private async void FacebookLogin(object sender, EventArgs e)
      {
         url = await model.GetFacebookLoginURL();
         
         if (url != null)
         {
            safariVC = new SFSafariViewController(new NSUrl(url.ToString()));
            PresentViewController(safariVC, true, null);
         }
      }

      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         base.PrepareForSegue(segue, sender);

         if (segue.Identifier == "CreateAccountSegue")
         {
            var destVC = segue.DestinationViewController as CreateAccountViewController;
            destVC.RegistrationSuccess += OnRegistrationSuccess;
         }
      }

      private void OnRegistrationSuccess(object sender, EventArgs e)
      {
         NavigationController.PopViewController(true);
      }
   }
}