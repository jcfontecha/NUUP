using Foundation;
using NUUP.Core;
using System;
using UIKit;

namespace NUUP.iOS
{
   public partial class CreateAccountViewController : UIViewController
   {
      private CreateAccountModel model;

      public event EventHandler RegistrationSuccess;

      public CreateAccountViewController(IntPtr handle) : base(handle)
      {
         model = new CreateAccountModel();
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         CreateAccountButton.TouchUpInside += OnCreateAccountButtonPressed;

         LoadingActivityIndicatorView.Hidden = true;
      }

      private void OnCreateAccountButtonPressed(object sender, EventArgs e)
      {
         CreateAccount();
      }

      private bool ValidateFields()
      {
         if (!IsValidEmail(EmailTextField.Text))
         {
            ShowError("La dirección de correo electrónico no es válida");
            return false;
         }

         return true;
      }

      public async void CreateAccount()
      {
         if (ValidateFields())
         {
            LoadingActivityIndicatorView.Hidden = false;
            LoadingActivityIndicatorView.StartAnimating();
            CreateAccountButton.Enabled = false;

            await model.SendNUUPRegistration(NameTextField.Text, LastNameTextField.Text, EmailTextField.Text);

            LoadingActivityIndicatorView.Hidden = true;
            LoadingActivityIndicatorView.StopAnimating();

            var alertController = UIAlertController.Create("Éxito", "Revisa tu correo para confirmar tu cuenta", UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (a) => OnRegistrationSuccess(new EventArgs())));

            PresentViewController(alertController, true, null);
         }
      }

      private void ShowError(string message)
      {
         var alertController = UIAlertController.Create("Error", message, UIAlertControllerStyle.Alert);
         alertController.AddAction(UIAlertAction.Create("Volver a intentarlo", UIAlertActionStyle.Default, null));

         PresentViewController(alertController, true, null);
      }

      private bool IsValidEmail(string email)
      {
         try
         {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
         }
         catch
         {
            return false;
         }
      }

      protected virtual void OnRegistrationSuccess(EventArgs e)
      {
         RegistrationSuccess?.Invoke(this, e);
      }
   }
}