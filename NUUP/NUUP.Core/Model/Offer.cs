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
      public static readonly string IdOfferField = "idOffer";
      public static readonly string CostField = "cost";
      public static readonly string DescriptionField = "description";
      public static readonly string IdSubjectField = "idSubject";
      public static readonly string IdUserField = "idUser";
      public static readonly string IdIntervalField = "idInterval";
      public static readonly string CreationField = "creation";
      public static readonly string AvailableField = "available";
      public static readonly string UserField = "user_by_idUser";
      public static readonly string SubjectField = "subject_by_idSubject";
      public static readonly string IntervalField = "interval_by_idInterval";
      public static readonly string SessionsField = "session_by_idOffer";

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
