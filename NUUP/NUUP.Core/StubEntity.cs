using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   class StubEntity : IEntity
   {
      public int IdStubEntity { get; set; }
      public string Content { get; set; }

      public Task DeserializeAsync(string serializedForm)
      {
         throw new NotImplementedException();
      }

      public string GetTableName()
      {
         return "StubEntity";
      }

      public async Task<string> SerializeAsync()
      {
         string result = "";
         await Task.Run(() =>
         {
            result += "{\n";
            result += string.Format("\t\"idStubEntity\": {1},\n", IdStubEntity);
            result += string.Format("\t\"content\": {1}\n", Content);
            result += "}";
         });

         return result;
      }
   }
}
