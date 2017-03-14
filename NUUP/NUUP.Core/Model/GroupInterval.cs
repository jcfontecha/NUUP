using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NUUP.Core.Model
{
   [DataContract]
   public class GroupInterval : IEntity
   {
      [DataMember]
      public int IdGroup { get; set; }
      [DataMember]
      public int IdInterval { get; set; }
   }
}
