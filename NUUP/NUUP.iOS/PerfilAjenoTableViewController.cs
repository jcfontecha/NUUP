using Foundation;
using System;
using UIKit;
using NUUP.Core.Model;
using NUUP.Core;
using System.Threading.Tasks;

namespace NUUP.iOS
{
   public partial class PerfilAjenoTableViewController : UITableViewController
   {
      private DataAccess dataAccess;
      public User User { get; set; }

      public PerfilAjenoTableViewController(IntPtr handle) : base(handle)
      {
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();
         dataAccess = new DataAccess();

         NombreLabel.Text = "...";
         EstudiosLabel.Text = "...";
         TutorLabel.Text = "...";
         AlumnoLabel.Text = "...";
         DescripcionLabel.Text = "...";

         await GetDataAsync();
      }

      private async Task GetDataAsync()
      {
         await Helper.GetDataAsync(TableView, () => dataAccess.CompleteSingleUserAsync(User).Wait());

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