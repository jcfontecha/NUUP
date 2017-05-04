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
   public class Place
   {
      [JsonProperty("idPlace")]
      public int IdPlace { get; set; }

      [JsonProperty("label")]
      public int Label { get; set; }

      public Place()
      {

      }
   }
}
