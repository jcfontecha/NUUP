using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class Degree
   {
      [JsonProperty("idDegree")]
      public int IdDegree { get; set; }

      [JsonProperty("label")]
      public string Label { get; set; }

      [JsonProperty("user_by_idDegree")]
      public List<User> Users { get; set; }

      public Degree()
      {
      }
   }
}
