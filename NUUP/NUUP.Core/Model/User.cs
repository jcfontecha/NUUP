using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Models
{
   public class User
   {
      public int IdUser { get; set; }
      public int IdDreamfactory { get; set; }
      public DateTime Birthday { get; set; }
      public float Lat { get; set; }
      public float Lng { get; set; }
      public int IdDegree { get; set; }
      public DateTime Creation { get; set; }
      public float RatingTutor { get; set; }
      public float RatingStudent { get; set; }
   }
}