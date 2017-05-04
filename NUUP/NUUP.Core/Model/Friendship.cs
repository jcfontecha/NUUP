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
   public class Friendship
   {
      [JsonProperty("idFriendship")]
      public int IdFriendship { get; set; }

      [JsonProperty("idUser1")]
      public int IdUser1 { get; set; }

      [JsonProperty("idUser2")]
      public int IdUser2 { get; set; }

      [JsonProperty("creation")]
      public DateTime Creation { get; set; }


      [JsonProperty("user_by_idUser1")]
      public User User1 { get; set; }

      [JsonProperty("user_by_idUser2")]
      public User User2 { get; set; }

      public Friendship()
      {

      }
   }
}
