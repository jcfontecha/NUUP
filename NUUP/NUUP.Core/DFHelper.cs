using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class DFHelper
   {
      /// <summary>
      /// Facebook JSON POST request to user/session
      /// </summary>
      public static string FacebookRequestString { get; } = "{\"service\": \"facebook\"}";

      /// <summary>
      /// Returns the corresponding header to prevent redirection. Useful when requesting 
      /// Facebook Login API URL to DreamFactory, for instance.
      /// </summary>
      public static Tuple<string, string> AvoidRedirectHeader { get; }
         = new Tuple<string, string>("X-Requested-With", "XMLHttpRequest");

      /// <summary>
      /// DreamFactory URL format to POST after Facebook callback to login user.
      /// </summary>
      /// <param name="query">Params returned from Facebook</param>
      /// <returns></returns>
      public static string FormatFacebookCallbackRequest(string query)
      {
         return "?oauth_callback=true&" + query;
      }

      /// <summary>
      /// Wraps the string in a resource tag. Like so: { "resource" : [ ... ] }
      /// </summary>
      /// <param name="json"></param>
      /// <returns></returns>
      public static string WrapInResourceTag(string json)
      {
         string final = "{ ";
         final += "\"resource\": [";
         final += json;
         final += "] }";

         return final;
      }


   }
}
