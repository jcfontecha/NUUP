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
   public class Interval
   {
      [JsonProperty("idInterval")]
      public int IdInterval { get; set; }

      [JsonProperty("startTime")]
      public TimeSpan startTime { get; set; }

      [JsonProperty("endTime")]
      public TimeSpan endTime { get; set; }

      [JsonProperty("idWeekday")]
      public int IdWeekday { get; set; }


      [JsonProperty("weekday_by_idWeekday")]
      public Weekday Weekday { get; set; }

      public Interval()
      {

      }
   }
}
