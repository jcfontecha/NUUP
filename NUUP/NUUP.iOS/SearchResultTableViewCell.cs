using Foundation;
using NUUP.Core.Model;
using System;
using System.Linq;
using UIKit;

namespace NUUP.iOS
{
   public partial class SearchResultTableViewCell : UITableViewCell
   {
      public SearchResultTableViewCell(IntPtr handle) : base(handle)
      {
      }

      public void UpdateCell(Offer offer)
      {
         try
         {
            SubjectNameLabel.Text = offer.Subject.Name;
            TutorNameLabel.Text = offer.User.DisplayName;
            DescriptionLabel.Text = offer.Description;
            TimeLabel.Text = offer.Interval.Weekday.Label + " " + offer.Interval.StartTime.ToString() + " - " + offer.Interval.EndTime.ToString();
         }
         catch (Exception e)
         {
            throw new ArgumentException("The offer sent to this cell is not valid", e);
         }
      }

      public void UpdateCell(Group group)
      {
         try
         {
            SubjectNameLabel.Text = group.Name;
            TutorNameLabel.Text = group.Tutor.DisplayName;
            DescriptionLabel.Text = group.Description;
            TimeLabel.Text = string.Join(",", group.Intervals.Select(x => x.Weekday.Label + " " + x.StartTime.ToString() + " - " + x.EndTime.ToString()));
         }
         catch (Exception e)
         {
            throw new ArgumentException("The group sent to this cell is not valid", e);
         }
      }
   }
}