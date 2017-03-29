using Foundation;
using System;
using UIKit;
using NUUP.Core.Model;

namespace NUUP.iOS
{
   public partial class PerfilAjenoTableViewController : UITableViewController
   {
      public User User { get; set; }

      public PerfilAjenoTableViewController(IntPtr handle) : base(handle)
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         if (User == null)
         {
            User = new User() { Nombre = "Juan Carlos" };
         }

         NombreLabel.Text = User.Nombre;
      }
   }
}