using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NUUP.Core.Model
{
   [DataContract]
   public class UsrLooksforSubject : IEntity
   {
      [DataMember]
      public int IdUser { get; set; }
      [DataMember]
      public int IdSubject { get; set; }
   }
}
