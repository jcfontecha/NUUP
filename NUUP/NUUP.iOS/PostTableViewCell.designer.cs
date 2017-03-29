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
        UIKit.UILabel authorLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView perfilImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView postBackgroundView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel postLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (authorLabel != null) {
                authorLabel.Dispose ();
                authorLabel = null;
            }

            if (perfilImage != null) {
                perfilImage.Dispose ();
                perfilImage = null;
            }

            if (postBackgroundView != null) {
                postBackgroundView.Dispose ();
                postBackgroundView = null;
            }

            if (postLabel != null) {
                postLabel.Dispose ();
                postLabel = null;
            }
        }
    }
}