using System;
using CoreGraphics;

using UIKit;

namespace NUUP.iOS
{
   public partial class ClasePageViewController : UIViewController
   {
      public UILabel Label { get; set; }

      private string text;
      public string Text
      {
         get
         {
            return text;
         }
         set
         {
            text = value;

            if (Label != null)
            {
               Label.Text = text;

               Label.Frame = new CGRect(
                  View.Frame.Width / 2 - Label.Bounds.Size.Width,
                  View.Frame.Height / 2 - Label.Bounds.Size.Height,
                  Label.Bounds.Size.Width,
                  Label.Bounds.Size.Height
               );
            }
         }
      }

      public UIImage Image { get; set; }
      public int Index { get; set; }

      public ClasePageViewController() : base("ClasePageViewController", null)
      {
      }

      public ClasePageViewController(CGRect frame)
      {
         base.Init();

         View.Frame = frame;
      }

      public ClasePageViewController(CGRect frame, string text)
      {
         base.Init();

         View.Frame = frame;
         Text = text;
      }

		public ClasePageViewController(CGRect frame, string text, int index)
		{
			base.Init();

			View.Frame = frame;
			Text = text;
         Index = index;
		}

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();
         // Perform any additional setup after loading the view, typically from a nib.

         var label = new UILabel();
         View.AddSubview(label);
         Text = "Default";
      }

      public override void DidReceiveMemoryWarning()
      {
         base.DidReceiveMemoryWarning();
         // Release any cached data, images, etc that aren't in use.
      }
   }
}

