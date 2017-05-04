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
   public class FriendRequest
   {
      [JsonProperty("idFriendRequest")]
      public int IdFriendRequest { get; set; }

      [JsonProperty("idUserFrom")]
      public int IdUserFrom { get; set; }

      [JsonProperty("idUserTo")]
      public int IdUserTo { get; set; }

      [JsonProperty("creation")]
      public DateTime Creation { get; set; }

      [JsonProperty("user_by_idUserFrom")]
      public User UserFrom { get; set; }

      [JsonProperty("user_by_idUserTo")]
      public User UserTo { get; set; }

      public FriendRequest()
      {

      }
   }
}
