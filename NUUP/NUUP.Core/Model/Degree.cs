using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core.Model
{
   public class Degree
   {
      public int IdDegree { get; set; }
      public string Label { get; set; }

      public List<User> Users { get; set; }

      public Degree()
      {
      }
   }
}
