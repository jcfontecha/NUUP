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

      public SearchResults()
      {
         Subjects = new List<Subject>();
         Offers = new List<Offer>();
         Groups = new List<Group>();
      }
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

            string subjectFilter = string.Join(" or ", subjects.Select(x => string.Format("(idSubject = {0})", x.IdSubject)));

            // Get Offers
            var offerRequest = new RecordRequest()
            {
               Path = Path.NuupOffer,
               Related = new[] { Offer.UserField, Offer.IntervalField },
               Filter = string.Format("((description like %{0}%) or {1}) and (available = 1)", term, string.Join(" or ", subjectFilter)),
               Limit = "20",
               Order = "creation DESC"
            };

            var offers = await service.GetResourceArrayAsync<List<Offer>>(offerRequest);

            // Set subject fields for Offers
            foreach (var offer in offers)
            {
               offer.Subject = subjects.Where(x => x.IdSubject == offer.IdSubject).First();
            }

            // Set User fields for Offers
            await FillDreamFactoryUsers(offers.Select(x => x.User));

            // Set Intervals and Weekdays and stuff
            var weekdays = await cache.GetWeekdaysAsync(false);

            foreach (var offer in offers)
            {
               offer.Interval.Weekday = weekdays.Where(x => x.IdWeekday == offer.Interval.IdWeekday).First();
            }

            // Get Groups
            var groupRequest = new RecordRequest()
            {
               Path = Path.NuupGroup,
               Related = new[] { Group.TutorField, Group.IntervalsField },
               Filter = string.Format("(name like %{0}%) or (description like %{1}%)", term, term),
               Limit = "20",
               Order = "creation DESC"
            };

            var groups = await service.GetResourceArrayAsync<List<Group>>(groupRequest);

            // Set User fields for Offers
            await FillDreamFactoryUsers(groups.Select(x => x.Tutor));

            foreach (var group in groups)
            {
               foreach (var interval in group.Intervals)
               {
                  interval.Weekday = weekdays.Where(x => x.IdWeekday == interval.IdWeekday).First();
               }
            }

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
