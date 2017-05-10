using Foundation;
using NUUP.Core.Model;
using System;
using System.Linq;
using UIKit;

namespace NUUP.iOS
{
   public partial class GroupDetailTableViewController : UITableViewController
   {
      public Group Group { get; set; }

      public GroupDetailTableViewController(IntPtr handle) : base(handle)
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         SetupUI();
      }

      private void SetupUI()
      {
         TutorLabel.Text = "Tutor";
         TutorNameLabel.Text = Group.Tutor.DisplayName;
         TutorRatingLabel.Text = Group.Tutor.RatingTutor + " estrellas";
         GroupNameLabel.Text = Group.Name;
         GroupIntervalsLabel.Text = string.Join(",", Group.Intervals.Select(x => x.Weekday.Label + " " + x.StartTime.ToString() + " - " + x.EndTime.ToString()));
         GroupDescriptionTextView.Text = Group.Description;
         CostLabel.Text = "Costo: $" + Group.Cost;
      }
   }
}