using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class Post
   {
      public int IdPost { get; set; }
      public int IdUser { get; set; }
      public string Text { get; set; }
      public DateTime Date { get; set; }

      public User User { get; set; }

      public Post()
      {

      }
   }
}
