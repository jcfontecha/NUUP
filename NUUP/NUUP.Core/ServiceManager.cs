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

      #region Header methods

      public void AddHeader(string key, string value)
      {
         client.DefaultRequestHeaders.Add(key, value);
      }

      public void RemoveHeader(string key)
      {
         client.DefaultRequestHeaders.Remove(key);
      }

      #endregion

      #region HTTP Requests Methods

      public async Task<string> GetResourceJSONAsync(RecordRequest request)
      {
         var requestString = request.ToString();
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
         try
         {
            var json = await GetResourceJSONAsync(request);
            var jObject = JObject.Parse(json);
            return jObject;
         }
         catch (Exception)
         {
            throw new Exception("Hubo un error al parsear la respuesta");
         }
      }

      public async Task<JArray> GetResourceArrayAsync(RecordRequest request)
      {
         try
         {
            var jObject = await GetResourceAsync(request);
            var jArray = JArray.Parse(jObject["resource"].ToString());
            return jArray;
         }
         catch (Exception)
         {
            throw new Exception("Hubo un error al procesar el arreglo.");
         }
      }

      public async Task<T> GetResourceArrayAsync<T>(RecordRequest request)
      {
         try
         {
            var jObject = await GetResourceAsync(request);
            var jToken = jObject["resource"];
            return jToken.ToObject<T>();
         }
         catch (Exception)
         {
            throw new Exception("Hubo un error al procesar el arreglo del tipo " + typeof(T).ToString());
         }
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


      #endregion

   }
}
