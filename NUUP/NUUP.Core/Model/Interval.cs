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
      public static readonly string IdIntervalField = "idInterval";
      public static readonly string StartTimeField = "startTime";
      public static readonly string EndTimeField = "endTime";
      public static readonly string IdWeekdayField = "idWeekday";
      public static readonly string WeekdayField = "weekday_by_idWeekday";

      [JsonProperty("idInterval")]
      public int IdInterval { get; set; }

      [JsonProperty("startTime")]
      public TimeSpan StartTime { get; set; }

      [JsonProperty("endTime")]
      public TimeSpan EndTime { get; set; }

      [JsonProperty("idWeekday")]
      public int IdWeekday { get; set; }


      [JsonProperty("weekday_by_idWeekday")]
      public Weekday Weekday { get; set; }

      public Interval()
      {

      }
   }
}
