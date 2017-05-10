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
    [Register ("EditSessionTableViewController")]
    partial class EditSessionTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CostLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EndDateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel IntervalLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LocationLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StartDateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SubjectNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserRatingLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserRoleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CostLabel != null) {
                CostLabel.Dispose ();
                CostLabel = null;
            }

            if (EndDateLabel != null) {
                EndDateLabel.Dispose ();
                EndDateLabel = null;
            }

            if (IntervalLabel != null) {
                IntervalLabel.Dispose ();
                IntervalLabel = null;
            }

            if (LocationLabel != null) {
                LocationLabel.Dispose ();
                LocationLabel = null;
            }

            if (StartDateLabel != null) {
                StartDateLabel.Dispose ();
                StartDateLabel = null;
            }

            if (SubjectNameLabel != null) {
                SubjectNameLabel.Dispose ();
                SubjectNameLabel = null;
            }

            if (UserNameLabel != null) {
                UserNameLabel.Dispose ();
                UserNameLabel = null;
            }

            if (UserRatingLabel != null) {
                UserRatingLabel.Dispose ();
                UserRatingLabel = null;
            }

            if (UserRoleLabel != null) {
                UserRoleLabel.Dispose ();
                UserRoleLabel = null;
            }
        }
    }
}