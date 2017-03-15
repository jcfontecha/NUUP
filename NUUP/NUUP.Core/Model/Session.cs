using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class Session
   {
      public int IdSession { get; set; }
      public DateTime StartDate { get; set; }
      public int Hours { get; set; }
      public float Cost { get; set; }
      public int IdOffer { get; set; }
      public int IdInterval { get; set; }
      public int IdState { get; set; }
      public int IdPlace { get; set; }
      public float? Lat { get; set; }
      public float? Lng { get; set; }
      public int IdTutor { get; set; }
      public int IdStudent { get; set; }
      public string OtherLocation { get; set; }
      public DateTime EndDate { get; set; }

      public Offer Offer { get; set; }
      public Interval Interval { get; set; }
      public State State { get; set; }
      public Place Place { get; set; }
      public User Tutor { get; set; }
      public User Student { get; set; }

      public Session()
      {

      }
   }
}
