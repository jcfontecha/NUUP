﻿using System;
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
   public class Weekday
   {
      public static readonly string IdWeekdayField = "idWeekday";
      public static readonly string LabelField = "label";

      [JsonProperty("idWeekday")]
      public int IdWeekday { get; set; }

      [JsonProperty("label")]
      public string Label { get; set; }

      public Weekday()
      {
      }
   }
}
