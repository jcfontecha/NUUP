using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class CacheManager
   {
      private List<Category> categories;
      private List<Place> places;
      private List<State> states;
      private List<Subject> subjects;
      private List<Weekday> weekdays;

      public List<User> Users { get; set; }

      private static CacheManager instance;
      public static CacheManager Instance
      {
         get
         {
            if (instance == null)
            {
               instance = new CacheManager();
            }

            return instance;
         }
      }

      private CacheManager()
      {
         categories = new List<Category>();
         places = new List<Place>();
         states = new List<State>();
         subjects = new List<Subject>();
         weekdays = new List<Weekday>();
         Users = new List<User>();
      }

      public void ClearCategoriesCache()
      {
         categories = new List<Category>();
      }

      public void ClearPlacesCache()
      {
         places = new List<Place>();
      }

      public void ClearStatesCache()
      {
         states = new List<State>();
      }

      public void ClearSubjectsCache()
      {
         subjects = new List<Subject>();
      }

      public void ClearWeekdaysCache()
      {
         weekdays = new List<Weekday>();
      }

      public void ClearUsersCache()
      {
         Users = new List<User>();
      }

      public async Task<List<Category>> GetCategoriesAsync(bool forceRefresh)
      {
         if (categories.Count == 0 || forceRefresh)
         {
            var service = ServiceManager.Instance;

            var request = new RecordRequest()
            {
               Path = Path.NuupCategory
            };

            categories = await service.GetResourceArrayAsync<List<Category>>(request);
         }

         return categories;
      }

      public async Task<List<Place>> GetPlacesAsync(bool forceRefresh)
      {
         if (places.Count == 0 || forceRefresh)
         {
            var service = ServiceManager.Instance;

            var request = new RecordRequest()
            {
               Path = Path.NuupPlace
            };

            places = await service.GetResourceArrayAsync<List<Place>>(request);
         }

         return places;
      }

      public async Task<List<State>> GetStatesAsync(bool forceRefresh)
      {
         if (states.Count == 0 || forceRefresh)
         {
            var service = ServiceManager.Instance;

            var request = new RecordRequest()
            {
               Path = Path.NuupState
            };

            states = await service.GetResourceArrayAsync<List<State>>(request);
         }

         return states;
      }

      public async Task<List<Subject>> GetSubjectsAsync(bool forceRefresh)
      {
         if (subjects.Count == 0 || forceRefresh)
         {
            var service = ServiceManager.Instance;

            var request = new RecordRequest()
            {
               Path = Path.NuupSubject
            };

            subjects = await service.GetResourceArrayAsync<List<Subject>>(request);
         }

         return subjects;
      }

      public async Task<List<Weekday>> GetWeekdaysAsync(bool forceRefresh)
      {
         if (weekdays.Count == 0 || forceRefresh)
         {
            var service = ServiceManager.Instance;

            var request = new RecordRequest()
            {
               Path = Path.NuupWeekday
            };

            weekdays = await service.GetResourceArrayAsync<List<Weekday>>(request);
         }

         return weekdays;
      }
   }
}
