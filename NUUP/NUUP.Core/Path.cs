using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   /// <summary>
   /// This class works like an ENUM with associated string values.
   /// It's one way to group all the string constants regarding
   /// DreamFactory paths for Request calls.
   /// </summary>
   public class Path
   {
      /// <summary>
      /// String value for current Path
      /// </summary>
      public string Value;

      public static Path NuupUser { get; } = new Path("nuup/_table/user");
      public static Path NuupPost { get; } = new Path("nuup/_table/post");
      public static Path NuupDegree { get; } = new Path("nuup/_table/degree");
      public static Path NuupCategory { get; } = new Path("nuup/_table/category");
      public static Path NuupSubject { get; } = new Path("nuup/_table/subject");
      public static Path NuupOffer { get; } = new Path("nuup/_table/offer");

      public static Path User { get; } = new Path("user");
      public static Path UserSession { get; } = new Path("user/session");
      public static Path SystemUser { get; } = new Path("system/user");

      private Path(string value)
      {
         Value = value;
      }
   }
}
