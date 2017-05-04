using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class SubjectsModel : NUUPModel
   {
      public async Task<List<Category>> GetCategories()
      {
         var request = new RecordRequest()
         {
            Path = Path.NuupCategory
         };

         var categories = await service.GetResourceArrayAsync<List<Category>>(request);

         return categories;
      }

      public async Task<List<Subject>> GetSubjectsForCategory(Category category)
      {
         var request = new RecordRequest()
         {
            Path = Path.NuupSubject,
            Filter = "idCategory = " + category.IdCategory
         };

         var subjects = await service.GetResourceArrayAsync<List<Subject>>(request);

         foreach (var subject in subjects)
         {
            subject.Category = category;
         }

         category.Subjects = subjects;

         return subjects;
      }
   }
}
