using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.UI;

namespace WebMVC
{
    public static class GlobalVariable
    {
        public static HttpClient WebApiClient = new HttpClient();
        // cấu hình đường dẫn api vào
        static GlobalVariable()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44356/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}