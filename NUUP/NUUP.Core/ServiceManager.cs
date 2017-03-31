using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUUP.Core
{
   public class ServiceManager
   {
      private HttpClient client { get; set; }
      private static ServiceManager instance;
      static readonly string serviceAPIKey = "52645c354662c8c2681dd3d6e552157adc089ad55e3a1979703be8b90f7b7a85";
      static readonly string serviceURL = "http://ec2-35-163-58-56.us-west-2.compute.amazonaws.com";

      public static ServiceManager Instance
      {
         get
         {
            if (instance == null)
            {
               instance = new ServiceManager();
            }

            return instance;
         }
      }

      private ServiceManager()
      {
         client = new HttpClient();

         client.BaseAddress = new Uri(serviceURL + "/api/v2/");
         client.DefaultRequestHeaders.Accept.Clear();
         client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         client.DefaultRequestHeaders.Add("X-DreamFactory-Api-Key", serviceAPIKey);
      }

      public async Task<string> GetResourceAsync(string path)
      {
         HttpResponseMessage response = await client.GetAsync(path);

         if (response.IsSuccessStatusCode)
         {
            return await response.Content.ReadAsStringAsync();
         }
         else
         {
            throw new Exception("There was an error getting the resource");
         }
      }
   }
}
