using Foundation;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Linq;
using UIKit;

namespace NUUP.iOS
{
   public partial class EditSessionTableViewController : UITableViewController
   {
      public Offer Offer { get; set; }
      public Session Session { get; set; }
      private SessionModel model;

      public EditSessionTableViewController(IntPtr handle) : base(handle)
      {
         model = new SessionModel();
      }

      public override async void ViewDidLoad()
      {
         base.ViewDidLoad();

         var sessionManager = SessionManager.Instance;

         Session = new Session();
         Session.IdInterval = Offer.IdInterval;
         Session.Interval = Offer.Interval;

         Session.IdTutor = Offer.IdUser;
         Session.Tutor = Offer.User;

         //Session.IdStudent = sessionManager.User.IdUser;
         //Session.Student = sessionManager.User;

         Session.IdOffer = Offer.IdOffer;
         Session.Offer = Offer;

         Session.Cost = Offer.Cost;

         Session.Hours = 2;

         Session.IdState = 1;

         Session.StartDate = DateTime.Now;
         var weekLater = DateTime.Now;
         weekLater.AddDays(7);
         Session.EndDate = weekLater;

         Session.IdPlace = 1;
         await Helper.GetDataForTableAsync(this, async () =>
         {
            var places = await CacheManager.Instance.GetPlacesAsync(false);
            Session.Place = places.Where(x => x.IdPlace == Session.IdPlace).First();
         });

         UpdateSession();
      }

      private void UpdateSession()
      {
         // TODO: Actualizar esto dependiendo del usuario con la sesión iniciada
         UserRoleLabel.Text = "Tutor";
         UserNameLabel.Text = Session.Tutor.DisplayName;
         UserRatingLabel.Text = Session.Tutor.RatingStudent + " estrellas";
         SubjectNameLabel.Text = Session.Offer.Subject.Name;
         StartDateLabel.Text = Session.StartDate.ToShortDateString();
         EndDateLabel.Text = Session.EndDate.ToShortDateString();
         LocationLabel.Text = Session.Place.Label;
      }
   }
}