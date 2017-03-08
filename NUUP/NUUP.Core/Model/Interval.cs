using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Models
{
   public class Interval
   {
      public int IdInterval { get; set; }
      public time StartTime { get; set; }
      public time EndTime { get; set; }
      public int IdWeekday { get; set; }
   }
}