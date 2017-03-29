using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUUP.Core.Model;

namespace NUUP.Core
{
   public class DataAccess
   {
      private ServiceManager service = new ServiceManager();
      public User LoggedInUser { get; set; }

      public DataAccess()
      {
      }

      public async Task<List<Post>> GetLatestNews()
      {
         var news = new List<Post>();

         await Task.Run(() =>
         {
            var post = new Post() { IdPost = 3, IdUser = 6, Date = DateTime.Today, Text = "Me gustaría aprender piano" };
            post.User = new User() { IdUser = 6, Nombre = "Jose Carlos", Apellido = "Suarez" };

            news.Add(post);

            var post2 = new Post() { IdPost = 3, IdUser = 7, Date = DateTime.Today, Text = "Doy clases de programación" };
            post2.User = new User() { IdUser = 7, Nombre = "Gerardo", Apellido = "Alcántara" };

            news.Add(post2);
         });

         return news;
      }

      public async Task<List<Category>> GetCategorias()
      {
         var categorias = new List<Category>();

         await Task.Run(() =>
         {
            var categoria = new Category() { IdCategory = 1, Label = "Matematicas" };
            categorias.Add(categoria);
            var categoria2 = new Category() { IdCategory = 2, Label = "Derecho" };
            categorias.Add(categoria2);
            var categoria3 = new Category() { IdCategory = 3, Label = "Humanidades" };
            categorias.Add(categoria3);
         });

         return categorias;
      }

      public async Task<List<Subject>> GetClasesForCategoriaAsync(Category category)
      {
         var clases = new List<Subject>();

         await Task.Run(() =>
         {
            var subject = new Subject() { IdSubject = 3, Name = "Calculo", IdCategory = category.IdCategory, Category = category };
            clases.Add(subject);
            var subject2 = new Subject() { IdSubject = 4, Name = "Algebra Lineal", IdCategory = category.IdCategory, Category = category };
            clases.Add(subject2);
         });

         return clases;
      }

      public async Task<List<Offer>> GetOfertasForSubjectAsync(Subject subject)
      {
         var ofertas = new List<Offer>();

         await Task.Run(() =>
         {
            var weekday = new Weekday() { IdWeekday = 1, Label = "Lunes" };
            var interval = new Interval() { IdInterval = 1, IdWeekday = weekday.IdWeekday, Weekday = weekday };
            interval.startTime = new TimeSpan(2, 0, 0);
            interval.endTime = new TimeSpan(4, 0, 0);

            var oferta = new Offer()
            {
               IdOffer = 3,
               Description = "Clases para principiantes",
               Interval = interval,
               IdInterval = interval.IdInterval,
               Subject = subject,
               IdSubject = subject.IdSubject
            };

            ofertas.Add(oferta);

            var weekday2 = new Weekday() { IdWeekday = 2, Label = "Martes" };
            var interval2 = new Interval() { IdInterval = 2, IdWeekday = weekday2.IdWeekday, Weekday = weekday };
            interval.startTime = new TimeSpan(3, 0, 0);
            interval.endTime = new TimeSpan(5, 0, 0);

            var oferta2 = new Offer()
            {
               IdOffer = 4,
               Description = "Clases intermedias, muy efectivas",
               Interval = interval2,
               IdInterval = interval2.IdInterval,
               Subject = subject,
               IdSubject = subject.IdSubject
            };

            ofertas.Add(oferta2);
         });

         return ofertas;
      }
   }
}
