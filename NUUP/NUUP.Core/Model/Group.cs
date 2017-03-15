using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class Group
   {
      public int IdGroup { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public int Cuota { get; set; }
      public float Cost { get; set; }
      public float? Lat { get; set; }
      public float? Lng { get; set; }
      public int IdTutor { get; set; }
      public DateTime Creation { get; set; }

      public User Tutor { get; set; }
      public List<Interval> Intervals { get; set; }
      public List<Membership> Memberships { get; set; }
      public List<User> Members { get; set; }

      public Group()
      {
      }
   }
}
