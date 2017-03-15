using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class Membership
   {
      public int IdMembership { get; set; }
      public int IdGroup { get; set; }
      public int IdUser { get; set; }
      public DateTime Creation { get; set; }

      public Group Group { get; set; }
      public User User { get; set; }

      public Membership()
      {
      }
   }
}
