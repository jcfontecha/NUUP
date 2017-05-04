using Foundation;
using System;
using UIKit;
using NUUP.Core.Model;
using NUUP.Core;
using System.Threading.Tasks;

namespace NUUP.iOS
{
   public partial class ProfileTableViewController : UITableViewController
   {
      private ProfileModel model;
      public User User { get; set; }

      public ProfileTableViewController(IntPtr handle) : base(handle)
      {
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();
         model = new ProfileModel();

         NombreLabel.Text = "...";
         EstudiosLabel.Text = "...";
         TutorLabel.Text = "...";
         AlumnoLabel.Text = "...";
         DescripcionLabel.Text = "...";

         await GetDataAsync();
      }

      private async Task GetDataAsync()
      {
         await Helper.GetDataAsync(this, true, async () => {
            await model.CompleteSingleUserAsync(User);
         });

         NombreLabel.Text = User.FirstName + " " + User.LastName;
         EstudiosLabel.Text = User.Degree.Label;
         TutorLabel.Text = User.RatingTutor + " estrellas";
         AlumnoLabel.Text = User.RatingStudent + " estrellas";
         DescripcionLabel.Text = User.Description;
      }

      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         base.PrepareForSegue(segue, sender);

         if (segue.Identifier == "EnviarMensajeSegue")
         {
            segue.DestinationViewController.HidesBottomBarWhenPushed = true;
         }
      }
   }
}