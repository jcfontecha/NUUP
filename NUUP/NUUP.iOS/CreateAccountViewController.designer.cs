// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NUUP.iOS
{
    [Register ("CreateAccountViewController")]
    partial class CreateAccountViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CreateAccountButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EmailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LastNameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView LoadingActivityIndicatorView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NameTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CreateAccountButton != null) {
                CreateAccountButton.Dispose ();
                CreateAccountButton = null;
            }

            if (EmailTextField != null) {
                EmailTextField.Dispose ();
                EmailTextField = null;
            }

            if (LastNameTextField != null) {
                LastNameTextField.Dispose ();
                LastNameTextField = null;
            }

            if (LoadingActivityIndicatorView != null) {
                LoadingActivityIndicatorView.Dispose ();
                LoadingActivityIndicatorView = null;
            }

            if (NameTextField != null) {
                NameTextField.Dispose ();
                NameTextField = null;
            }
        }
    }
}