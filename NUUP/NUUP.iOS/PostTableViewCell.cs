using Foundation;
using System;
using UIKit;

namespace NUUP.iOS
{
   public partial class PostTableViewCell : UITableViewCell
   {
      public UILabel AuthorLabel { get; set; }
      public UILabel PostLabel { get; set; }

      public PostTableViewCell(IntPtr handle) : base(handle)
      {
         AuthorLabel = authorLabel;
         PostLabel = postLabel;
      }
   }
}