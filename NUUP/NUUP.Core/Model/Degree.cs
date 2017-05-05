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
      public static readonly string IdDegreeField = "idDegree";
      public static readonly string LabelField = "label";
      public static readonly string UsersField = "user_by_idDegree";

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
