using Foundation;
using NUUP.Core.Model;
using System;
using UIKit;

namespace NUUP.iOS
{
   public partial class OfferDetailTableViewController : UITableViewController
   {
      public Offer Offer { get; set; }
      public OfferDetailTableViewController(IntPtr handle) : base(handle)
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         if (Offer != null)
         {
            UpdateOffer();
         }
         else
         {
            throw new Exception("An offer was not set for this View Controller");
         }
      }

      public void UpdateOffer()
      {
         TutorLabel.Text = "Tutor";
         TutorNameLabel.Text = Offer.User.DisplayName;
         TutorRatingLabel.Text = Offer.User.RatingTutor + " estrellas";
         CategoryLabel.Text = Offer.Subject.Category.Label;
         SubjectNameLabel.Text = Offer.Subject.Name;
         SubjectIntervalLabel.Text = Offer.Interval.Weekday.Label + " " + Offer.Interval.StartTime.ToString() + " - " + Offer.Interval.EndTime.ToString();
         SubjectDescriptionTextView.Text = Offer.Description;
         CostLabel.Text = "Costo: $" + Offer.Cost;
      }

      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         base.PrepareForSegue(segue, sender);

         if (segue.Identifier == "CreateSession")
         {
            var destVC = segue.DestinationViewController as EditSessionTableViewController;
            destVC.Offer = Offer;
         }
      }
   }
}