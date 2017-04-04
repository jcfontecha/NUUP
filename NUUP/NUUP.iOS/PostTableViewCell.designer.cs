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
    [Register ("PostTableViewCell")]
    partial class PostTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView PostContainerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PostLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProfileImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SeeProfileButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SendMessageButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NameLabel != null) {
                NameLabel.Dispose ();
                NameLabel = null;
            }

            if (PostContainerView != null) {
                PostContainerView.Dispose ();
                PostContainerView = null;
            }

            if (PostLabel != null) {
                PostLabel.Dispose ();
                PostLabel = null;
            }

            if (ProfileImage != null) {
                ProfileImage.Dispose ();
                ProfileImage = null;
            }

            if (SeeProfileButton != null) {
                SeeProfileButton.Dispose ();
                SeeProfileButton = null;
            }

            if (SendMessageButton != null) {
                SendMessageButton.Dispose ();
                SendMessageButton = null;
            }
        }
    }
}