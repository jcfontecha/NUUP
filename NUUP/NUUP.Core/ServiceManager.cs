using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUUP.Core.Model;
using Newtonsoft.Json;

namespace NUUP.Core
{
   public class ServiceManager
   {
      private HttpClientHandler clientHandler;
      private HttpClient client;
      private static ServiceManager instance;
      static readonly string serviceAPIKey = "b5a603f00422bdea581c6cee778cb2f161b59a6e97d8ded7ae27d0fdf37895c7";
      static readonly string serviceURL = "http://ec2-35-163-39-223.us-west-2.compute.amazonaws.com";

      private User LoggedInUser { get; set; }
      private string SessionToken { get; set; }

      public bool NeedsLogin
      {
         get
         {
            return LoggedInUser == null;
         }
      }

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

      public void LoginUser(User user, string sessionToken)
      {
         if (user != null)
         {
            LoggedInUser = user;
            SessionToken = sessionToken;
         }
      }

      public void AddHeader(string key, string value)
      {
         client.DefaultRequestHeaders.Add(key, value);
      }

      public void RemoveHeader(string key)
      {
         client.DefaultRequestHeaders.Remove(key);
      }

      public async Task<string> GetResourceJSONAsync(RecordRequest request)
      {
         HttpResponseMessage response = await client.GetAsync(request.ToString());

         if (response.IsSuccessStatusCode)
         {
            var json = await response.Content.ReadAsStringAsync();
            return json;
         }
         else
         {
            throw new Exception("There was an error getting the resource");
         }
      }

      public async Task<JObject> GetResourceAsync(RecordRequest request)
      {
         var json = await GetResourceJSONAsync(request);
         return JObject.Parse(json);
      }

      public async Task<T> GetResourceAsync<T>(RecordRequest request)
      {
         var jObject = await GetResourceAsync(request);

         try
         {
            return jObject.ToObject<T>();
         }
         catch (Exception)
         {
            throw new Exception("The response could not be deserialized as the desired type T");
         }
      }

      public async Task<JObject> PostResourceAsync(RecordRequest request, string json)
      {
         StringContent httpContent = null;
         if (!string.IsNullOrEmpty(json))
         {
            httpContent = new StringContent(json, Encoding.UTF8, "application/json");
         }

         HttpResponseMessage response = await client.PostAsync(request.ToString(), httpContent);

         if (response.IsSuccessStatusCode)
         {
            string responseJson = await response.Content.ReadAsStringAsync();
            return JObject.Parse(responseJson);
         }
         else
         {
            throw new Exception("There was an error posting the resource");
         }
      }
   }
}
