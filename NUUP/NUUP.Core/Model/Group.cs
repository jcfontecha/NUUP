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
   public class Group
   {
      public static readonly string User2Field = "user_by_idUser2";
      public static readonly string IdGroupField = "idGroup";
      public static readonly string NameField = "name";
      public static readonly string DescriptionField = "description";
      public static readonly string CuotaField = "quota";
      public static readonly string CostField = "cost";
      public static readonly string LatField = "lat";
      public static readonly string LngField = "lng";
      public static readonly string IdTutorField = "idTutor";
      public static readonly string CreationField = "creation";
      public static readonly string TutorField = "user_by_idTutor";
      public static readonly string IntervalsField = "interval_by_group_interval";
      public static readonly string MembershipsField = "membership_by_idGroup";
      public static readonly string MembersField = "user_by_membership";

      [JsonProperty("idGroup")]
      public int IdGroup { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("description")]
      public string Description { get; set; }

      [JsonProperty("quota")]
      public int Cuota { get; set; }

      [JsonProperty("cost")]
      public float Cost { get; set; }

      [JsonProperty("lat")]
      public float? Lat { get; set; }

      [JsonProperty("lng")]
      public float? Lng { get; set; }

      [JsonProperty("idTutor")]
      public int IdTutor { get; set; }

      [JsonProperty("creation")]
      public DateTime Creation { get; set; }

      [JsonProperty("user_by_idTutor")]
      public User Tutor { get; set; }

      [JsonProperty("interval_by_group_interval")]
      public List<Interval> Intervals { get; set; }

      [JsonProperty("membership_by_idGroup")]
      public List<Membership> Memberships { get; set; }

      [JsonProperty("user_by_membership")]
      public List<User> Members { get; set; }

      public Group()
      {
      }
   }
}
