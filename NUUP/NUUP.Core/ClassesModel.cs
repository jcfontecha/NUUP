using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class ClassesModel : NUUPModel
   {
      public async Task<List<Category>> GetCategories()
      {
         var request = new RecordRequest()
         {
            Path = Path.NuupCategory
         };

         var categoriesObject = await service.GetResourceAsync(request);
         var categoriesArray = DFHelper.ExtractResource(categoriesObject);
         var categories = categoriesArray.ToObject<List<Category>>();

         return categories;
      }

      public async Task<List<Subject>> GetSubjectsForCategory(Category category)
      {
         var request = new RecordRequest()
         {
            Path = Path.NuupSubject,
            Filter = "idCategory = " + category.IdCategory
         };

         var subjectsObject = await service.GetResourceAsync(request);
         var subjectsArray = DFHelper.ExtractResource(subjectsObject);
         var subjects = subjectsArray.ToObject<List<Subject>>();

         return subjects;
      }
   }
}
