using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using MyProject.Models;


namespace MyProject
{
    public static class HttpHeaderVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        static HttpHeaderVariables ()   
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44320/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}