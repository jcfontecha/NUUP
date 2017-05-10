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
    [Register ("GroupDetailTableViewController")]
    partial class GroupDetailTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CostLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView GroupDescriptionTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel GroupIntervalsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel GroupNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView TutorImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TutorLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TutorNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TutorRatingLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CostLabel != null) {
                CostLabel.Dispose ();
                CostLabel = null;
            }

            if (GroupDescriptionTextView != null) {
                GroupDescriptionTextView.Dispose ();
                GroupDescriptionTextView = null;
            }

            if (GroupIntervalsLabel != null) {
                GroupIntervalsLabel.Dispose ();
                GroupIntervalsLabel = null;
            }

            if (GroupNameLabel != null) {
                GroupNameLabel.Dispose ();
                GroupNameLabel = null;
            }

            if (TutorImageView != null) {
                TutorImageView.Dispose ();
                TutorImageView = null;
            }

            if (TutorLabel != null) {
                TutorLabel.Dispose ();
                TutorLabel = null;
            }

            if (TutorNameLabel != null) {
                TutorNameLabel.Dispose ();
                TutorNameLabel = null;
            }

            if (TutorRatingLabel != null) {
                TutorRatingLabel.Dispose ();
                TutorRatingLabel = null;
            }
        }
    }
}