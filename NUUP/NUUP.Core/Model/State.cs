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
   public class State
   {
      public static readonly string IdStateField = "idState";
      public static readonly string LabelField = "label";

      [JsonProperty("idState")]
      public int IdState { get; set; }

      [JsonProperty("label")]
      public string Label { get; set; }

      public State()
      {

      }
   }
}
