using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Models
{
   public class Membership
   {
      public int IdMembership { get; set; }
      public int IdGroup { get; set; }
      public int IdUser { get; set; }
      public DateTime Since { get; set; }
   }
}