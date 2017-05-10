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
    [Register ("OfferDetailTableViewController")]
    partial class OfferDetailTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CategoryLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CostLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView SubjectDescriptionTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SubjectIntervalLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SubjectNameLabel { get; set; }

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
            if (CategoryLabel != null) {
                CategoryLabel.Dispose ();
                CategoryLabel = null;
            }

            if (CostLabel != null) {
                CostLabel.Dispose ();
                CostLabel = null;
            }

            if (SubjectDescriptionTextView != null) {
                SubjectDescriptionTextView.Dispose ();
                SubjectDescriptionTextView = null;
            }

            if (SubjectIntervalLabel != null) {
                SubjectIntervalLabel.Dispose ();
                SubjectIntervalLabel = null;
            }

            if (SubjectNameLabel != null) {
                SubjectNameLabel.Dispose ();
                SubjectNameLabel = null;
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