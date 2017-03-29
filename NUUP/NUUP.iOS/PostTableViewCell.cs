using Foundation;
using System;
using UIKit;

namespace NUUP.iOS
{
   public partial class PostTableViewCell : UITableViewCell
   {
      private string author;
      public string Author {
         get
         {
            return author;
         }
         set
         {
            author = value;

            if (authorLabel != null)
            {
               authorLabel.Text = author;
            }
         }
      }

      private string post;
      public string Post
      {
         get
         {
            return post;
         }
         set
         {
            post = value;

            if (postLabel != null)
            {
               postLabel.Text = post;
            }
         }
      }

      public PostTableViewCell(IntPtr handle) : base(handle)
      {
         
      }

      public void UpdateCell(string author, string post)
      {
         authorLabel.Text = author;
         postLabel.Text = post;
      }

      public override void LayoutSubviews()
      {
			postBackgroundView.Layer.CornerRadius = 5.0f;

			postBackgroundView.Layer.ShadowColor = UIColor.Black.CGColor;
			postBackgroundView.Layer.ShadowOpacity = 0.2f;
			postBackgroundView.Layer.ShadowRadius = 4.0f;
			postBackgroundView.Layer.ShadowOffset = new CoreGraphics.CGSize(0.0f, 0.0f);
      }
   }
}