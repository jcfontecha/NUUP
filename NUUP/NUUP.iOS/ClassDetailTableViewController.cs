using Foundation;
using NUUP.Core.Model;
using System;
using UIKit;

namespace NUUP.iOS
{
   public partial class ClassDetailTableViewController : UITableViewController
   {
      public Offer Offer { get; set; }
      public ClassDetailTableViewController(IntPtr handle) : base(handle)
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         Offer = new Offer() { Description = "Hola viejo" };

         rolUsuarioLabel.Text = "Tutor";
         nombreUsuarioLabel.Text = "Gerardo Mathus";

         categoriaLabel.Text = "Matematicas";
         nombreMateriaLabel.Text = "Álgebra Lineal";
         horarioLabel.Text = "Lunes de 2pm a 4pm";
         descripcionLabel.Text = "Clase para principiantes de álgebra lineal¨con enfoque en vectores y principios de matrices";
      }
   }
}