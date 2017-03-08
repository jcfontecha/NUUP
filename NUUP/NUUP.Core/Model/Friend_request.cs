using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Models
{
   public class Friend_request
   {
      public int IdFriendRequest { get; set; }
      public int IdUserFrom { get; set; }
      public int IdUserTo { get; set; }
      public DateTime Date { get; set; }
   }
}