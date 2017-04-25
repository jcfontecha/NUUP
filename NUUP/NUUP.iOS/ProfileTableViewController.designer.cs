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
    [Register ("ProfileTableViewController")]
    partial class ProfileTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AlumnoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DescripcionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EstudiosLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NombreLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView PerfilImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TutorLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AlumnoLabel != null) {
                AlumnoLabel.Dispose ();
                AlumnoLabel = null;
            }

            if (DescripcionLabel != null) {
                DescripcionLabel.Dispose ();
                DescripcionLabel = null;
            }

            if (EstudiosLabel != null) {
                EstudiosLabel.Dispose ();
                EstudiosLabel = null;
            }

            if (NombreLabel != null) {
                NombreLabel.Dispose ();
                NombreLabel = null;
            }

            if (PerfilImage != null) {
                PerfilImage.Dispose ();
                PerfilImage = null;
            }

            if (TutorLabel != null) {
                TutorLabel.Dispose ();
                TutorLabel = null;
            }
        }
    }
}