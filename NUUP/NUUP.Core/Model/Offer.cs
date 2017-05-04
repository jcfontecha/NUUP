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
   public class Offer
   {
      [JsonProperty("idOffer")]
      public int IdOffer { get; set; }

      [JsonProperty("cost")]
      public float Cost { get; set; }

      [JsonProperty("description")]
      public string Description { get; set; }

      [JsonProperty("idSubject")]
      public int IdSubject { get; set; }

      [JsonProperty("idUser")]
      public int IdUser { get; set; }

      [JsonProperty("idInterval")]
      public int IdInterval { get; set; }

      [JsonProperty("creation")]
      public DateTime Creation { get; set; }

      [JsonProperty("available")]
      public bool Available { get; set; }

      [JsonProperty("user_by_idUser")]
      public User User { get; set; }

      [JsonProperty("subject_by_idSubject")]
      public Subject Subject { get; set; }

      [JsonProperty("interval_by_idInterval")]
      public Interval Interval { get; set; }

      [JsonProperty("session_by_idOffer")]
      public List<Session> Sessions { get; set; }

      public Offer()
      {

      }
   }
}
