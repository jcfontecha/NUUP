using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   interface IEntity
   {
      string GetTableName();
      Task<string> SerializeAsync();
      Task DeserializeAsync(string serializedForm);
   }
}
