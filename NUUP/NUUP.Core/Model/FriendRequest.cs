using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class FriendRequest
   {
      public int IdFriendRequest { get; set; }
      public int IdUserFrom { get; set; }
      public int IdUserTo { get; set; }
      public DateTime Creation { get; set; }

      public FriendRequest()
      {

      }
   }
}
