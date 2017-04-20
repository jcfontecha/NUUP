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
      private HttpClientHandler clientHandler;
      private HttpClient client;
      private static ServiceManager instance;
      static readonly string serviceAPIKey = "b5a603f00422bdea581c6cee778cb2f161b59a6e97d8ded7ae27d0fdf37895c7";
      static readonly string serviceURL = "http://ec2-35-163-39-223.us-west-2.compute.amazonaws.com";

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
         clientHandler = new HttpClientHandler();
         clientHandler.AllowAutoRedirect = false;

         client = new HttpClient(clientHandler);

         client.BaseAddress = new Uri(serviceURL + "/api/v2/");
         client.DefaultRequestHeaders.Accept.Clear();
         client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         client.DefaultRequestHeaders.Add("X-DreamFactory-Api-Key", serviceAPIKey);
      }

      public async Task<string> PostResourceAsync(string path, string json)
      {
         StringContent httpContent = null;
         if (!string.IsNullOrEmpty(json))
         {
            httpContent = new StringContent(json, Encoding.UTF8, "application/json");
         }

         HttpResponseMessage response = await client.PostAsync(path, httpContent);
         string contents = await response.Content.ReadAsStringAsync();

         return contents;
      }

      public async Task<string> PostResourceWithParametersAsync(string path, string parameters)
      {
         var url = client.BaseAddress + path + parameters;

         HttpResponseMessage response = await client.PostAsync(url, null);

         string contents = await response.Content.ReadAsStringAsync();

         return contents;
      }

      public async Task<string> PostResourceForRedirectAsync(string path, string json)
      {
         HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path);
         request.Content = new StringContent(json, Encoding.UTF8, "application/json");
         HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

         return response.Headers.Location.ToString();
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
