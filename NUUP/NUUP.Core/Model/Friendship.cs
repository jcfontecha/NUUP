using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Models
{
   public class Friendship
   {
      public int IdFriendship { get; set; }
      public int IdUser1 { get; set; }
      public int IdUser2 { get; set; }
      public DateTime Since { get; set; }
   }
}