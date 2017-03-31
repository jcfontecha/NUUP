using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class Post
   {
      [JsonProperty("idPost")]
      public int IdPost { get; set; }

      [JsonProperty("idUser")]
      public int IdUser { get; set; }

      [JsonProperty("text")]
      public string Text { get; set; }

      [JsonProperty("date")]
      public DateTime Date { get; set; }

      [JsonProperty("user_by_idUser")]
      public User User { get; set; }

      public Post()
      {

      }
   }
}
