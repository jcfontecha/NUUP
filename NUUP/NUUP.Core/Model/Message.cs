using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class Message
   {
      public int IdMessage { get; set; }
      public int IdUserFrom { get; set; }
      public int IdUserTo { get; set; }
      public string Text { get; set; }
      public DateTime Creation { get; set; }

      public User UserFrom { get; set; }
      public User UserTo { get; set; }

      public Message()
      {

      }
   }
}
