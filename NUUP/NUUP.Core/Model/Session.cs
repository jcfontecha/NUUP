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
