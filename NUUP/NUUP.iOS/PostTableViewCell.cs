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

            if (NameLabel != null)
            {
               NameLabel.Text = author;
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

            if (PostLabel != null)
            {
               PostLabel.Text = post;
            }
         }
      }

      public PostTableViewCell(IntPtr handle) : base(handle)
      {
         
      }

      public void UpdateCell(string author, string post)
      {
         NameLabel.Text = author;
         PostLabel.Text = post;
      }

      public override void LayoutSubviews()
      {
			PostContainerView.Layer.CornerRadius = 5.0f;

         PostContainerView.Layer.ShadowColor = UIColor.Black.CGColor;
         PostContainerView.Layer.ShadowOpacity = 0.2f;
         PostContainerView.Layer.ShadowRadius = 4.0f;
         PostContainerView.Layer.ShadowOffset = new CoreGraphics.CGSize(0.0f, 0.0f);
      }
   }
}