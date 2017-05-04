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
