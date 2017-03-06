using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUUP.Core
{
    public class ServiceManager
    {
        private HttpClient Client { get; set; }
        public string BaseURL { get; set; }

        public ServiceManager()
        {
            Client = new HttpClient();
            BaseURL = "http://ec2-54-197-40-152.compute-1.amazonaws.com/api/v2";

            Client.BaseAddress = new Uri("http://ec2-54-197-40-152.compute-1.amazonaws.com/api/v2/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
