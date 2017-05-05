using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NUUP.Core.Model
{
   public class Session
   {
      public static readonly string IdSessionField = "idSession";
      public static readonly string StartDateField = "startDate";
      public static readonly string HoursField = "hours";
      public static readonly string CostField = "cost";
      public static readonly string IdOfferField = "idOffer";
      public static readonly string IdIntervalField = "idInterval";
      public static readonly string IdStateField = "idState";
      public static readonly string IdPlaceField = "idPlace";
      public static readonly string LatField = "lat";
      public static readonly string LngField = "lng";
      public static readonly string IdTutorField = "idTutor";
      public static readonly string IdStudentField = "idStudent";
      public static readonly string OtherLocationField = "otherLocation";
      public static readonly string EndDateField = "endDate";
      public static readonly string OfferField = "offer_by_idOffer";
      public static readonly string IntervalField = "interval_by_idInterval";
      public static readonly string StateField = "state_by_idState";
      public static readonly string PlaceField = "place_by_idPlace";
      public static readonly string TutorField = "user_by_idTutor";
      public static readonly string StudentField = "user_by_idStudent";

      [JsonProperty("idSession")]
      public int IdSession { get; set; }

      [JsonProperty("startDate")]
      public DateTime StartDate { get; set; }

      [JsonProperty("hours")]
      public int Hours { get; set; }

      [JsonProperty("cost")]
      public float Cost { get; set; }

      [JsonProperty("idOffer")]
      public int IdOffer { get; set; }

      [JsonProperty("idInterval")]
      public int IdInterval { get; set; }

      [JsonProperty("idState")]
      public int IdState { get; set; }

      [JsonProperty("idPlace")]
      public int IdPlace { get; set; }

      [JsonProperty("lat")]
      public float? Lat { get; set; }

      [JsonProperty("lng")]
      public float? Lng { get; set; }

      [JsonProperty("idTutor")]
      public int IdTutor { get; set; }

      [JsonProperty("idStudent")]
      public int IdStudent { get; set; }

      [JsonProperty("otherLocation")]
      public string OtherLocation { get; set; }

      [JsonProperty("endDate")]
      public DateTime EndDate { get; set; }


      [JsonProperty("offer_by_idOffer")]
      public Offer Offer { get; set; }

      [JsonProperty("interval_by_idInterval")]
      public Interval Interval { get; set; }

      [JsonProperty("state_by_idState")]
      public State State { get; set; }

      [JsonProperty("place_by_idPlace")]
      public Place Place { get; set; }

      [JsonProperty("user_by_idTutor")]
      public User Tutor { get; set; }

      [JsonProperty("user_by_idStudent")]
      public User Student { get; set; }

      public Session()
      {

      }
   }
}
