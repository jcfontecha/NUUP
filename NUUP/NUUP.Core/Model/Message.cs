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
   public class Message
   {
      public static readonly string IdMessageField = "idMessage";
      public static readonly string IdUserFromField = "idUserFrom";
      public static readonly string IdUserToField = "idUserTo";
      public static readonly string TextField = "text";
      public static readonly string CreationField = "creation";
      public static readonly string UserFromField = "user_by_idUserFrom";
      public static readonly string UserToField = "user_by_idUserTo";

      [JsonProperty("idMessage")]
      public int IdMessage { get; set; }

      [JsonProperty("idUserFrom")]
      public int IdUserFrom { get; set; }

      [JsonProperty("idUserTo")]
      public int IdUserTo { get; set; }

      [JsonProperty("text")]
      public string Text { get; set; }

      [JsonProperty("creation")]
      public DateTime Creation { get; set; }

      [JsonProperty("user_by_idUserFrom")]
      public User UserFrom { get; set; }

      [JsonProperty("user_by_idUserTo")]
      public User UserTo { get; set; }

      public Message()
      {

      }
   }
}
