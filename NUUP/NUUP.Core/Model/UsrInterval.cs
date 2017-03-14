using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NUUP.Core.Model
{
   [DataContract]
   public class UsrInterval : IEntity
   {
      [DataMember]
      public int IdUser { get; set; }
      [DataMember]
      public int IdInterval { get; set; }
   }
}
