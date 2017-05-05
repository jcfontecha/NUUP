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
      public static readonly string IdPostField = "idPost";
      public static readonly string IdUserField = "idUser";
      public static readonly string TextField = "text";
      public static readonly string DateField = "date";
      public static readonly string UserField = "user_by_idUser";

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
         User = new User();
      }
   }
}
