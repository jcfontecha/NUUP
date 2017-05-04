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
   public class Membership
   {
      [JsonProperty("idMembership")]
      public int IdMembership { get; set; }

      [JsonProperty("idGroup")]
      public int IdGroup { get; set; }

      [JsonProperty("idUser")]
      public int IdUser { get; set; }

      [JsonProperty("creation")]
      public DateTime Creation { get; set; }


      [JsonProperty("group_by_idGroup")]
      public Group Group { get; set; }

      [JsonProperty("user_by_idUser")]
      public User User { get; set; }

      public Membership()
      {
      }
   }
}
