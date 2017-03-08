using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Models
{
   public class Offer
   {
      public int IdOffer { get; set; }
      public float Cost { get; set; }
      public string Description { get; set; }
      public int IdSubject { get; set; }
      public int IdUser { get; set; }
      public int IdInterval { get; set; }
      public DateTime Datetime { get; set; }
      public bool Available { get; set; }
   }
}