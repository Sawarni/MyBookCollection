using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyBookCollection.Services
{
    public static class Extensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string requestUri)
        {
            var myUri = $"{httpClient.BaseAddress}{requestUri}";
            var httpContent = await httpClient.GetAsync(myUri);
            string jsonContent = httpContent.Content.ReadAsStringAsync().Result;
            T obj = JsonConvert.DeserializeObject<T>(jsonContent);

            return obj;
        }

        public static async Task<HttpResponseMessage> PostJsonAsync<T>(this HttpClient httpClient, string requestUri, T content)
        {
            var myUri = $"{httpClient.BaseAddress}{requestUri}";
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(myUri, stringContent);

            return response;
        }

        public static async Task<HttpResponseMessage> PutJsonAsync<T>(this HttpClient httpClient, string requestUri, T content)
        {
            var myUri = $"{httpClient.BaseAddress}{requestUri}";
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(myUri, stringContent);

            return response;
        }
    }
}
