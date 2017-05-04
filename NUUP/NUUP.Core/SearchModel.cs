using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class SearchResults
   {
      public List<Subject> Subjects { get; set; }
      public List<Offer> Offers { get; set; }
      public List<Group> Groups { get; set; }
   }

   public class SearchModel : NUUPModel
   {
      public async Task<List<Subject>> SearchSubjectsAsync(string term)
      {
         var allSubjects = await cache.GetSubjectsAsync(false);
         var subjects = allSubjects.Where(x => x.Name.Contains(term)).ToList();

         return subjects;
      }

      public async Task<List<Category>> SearchCategoriesAsync(string term)
      {
         var cache = CacheManager.Instance;

         var categories = await cache.GetCategoriesAsync(false);

         return categories;
      }

      public async Task<SearchResults> GetSearchResultsAsync(string term)
      {
         try
         {
            // Get subjects
            var allSubjects = await cache.GetSubjectsAsync(false);
            var subjects = allSubjects.Where(x => x.Name.Contains(term)).ToList();

            // Get Offers
            var offerRequest = new RecordRequest()
            {
               Path = Path.NuupOffer,
               Filter = string.Format("(description like %{0}%) and (available = 1)", term),
               Limit = "20",
               Order = "creation DESC"
            };

            var offers = await service.GetResourceArrayAsync<List<Offer>>(offerRequest);

            // Get Groups
            var groupRequest = new RecordRequest()
            {
               Path = Path.NuupGroup,
               Filter = string.Format("(name like %{0}%) or (description like %{1}%)", term, term),
               Limit = "20",
               Order = "creation DESC"
            };

            var groups = await service.GetResourceArrayAsync<List<Group>>(groupRequest);

            var results = new SearchResults()
            {
               Subjects = subjects,
               Offers = offers,
               Groups = groups
            };

            return results;
         }
         catch (Exception e)
         {
            if (e is UnexpectedParsingException)
            {
               throw new ServerErrorException("There was an error getting the resource from the server", e);
            }
            else
            {
               throw e;
            }
         }
      }
   }
}
