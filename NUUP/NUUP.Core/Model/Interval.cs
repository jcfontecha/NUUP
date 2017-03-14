using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class Interval
   {
      public int IdInterval { get; set; }
      public TimeSpan startTime { get; set; }
      public TimeSpan endTime { get; set; }
      public int IdWeekday { get; set; }

      public Interval()
      {

      }
   }
}
