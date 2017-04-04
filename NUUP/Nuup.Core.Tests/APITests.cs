using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUUP.Core;
using NUUP.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuup.Core.Tests
{
   [TestClass]
   public class APITests
   {
      [TestMethod]
      public void TestUser()
      {
         var helper = new APITestsHelper();

         Task.Run(() => helper.TestUserAsync());
      }
   }

   class APITestsHelper
   {
      private DataAccess dataAccess = new DataAccess();

      public async void TestUserAsync()
      {
         User user = await dataAccess.GetUserAsync(1);
         Console.WriteLine(user);
         Console.WriteLine(user.ToString());
      }
   }
}
