using CrisBlazorApp.Business.Helpers;
using CrisBlazorApp.Business.Models;
using CrisBlazorApp.Business.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrisBlazorApp.Business.Services
{
    public class BlazorService : IBlazorService
    {
        private HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;
        private bool ConnectionChanged = false;
        public BlazorService(HttpClient client, IOptions<ApiSettings> options)
        {
            // Api configuration here and httpclient
            _apiSettings = options.Value;
            client.BaseAddress = new Uri(_apiSettings.FirstApi);

            _httpClient = client;
        }

        /// <summary>
        ///     Change the current connection
        /// </summary>
        public void ChangeConnection() { 
            ConnectionChanged = !ConnectionChanged;
            HttpClient newClient = new HttpClient();
            if (!ConnectionChanged)
                newClient.BaseAddress = new Uri(_apiSettings.FirstApi);
            else
                newClient.BaseAddress = new Uri(_apiSettings.SecondApi);

            _httpClient = newClient;
        }

        /// <summary>
        ///     Get all record by keyword provided
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<List<Dictionary<string, object>>> Retrieve(string keyword)
        {
            List<Dictionary<string, object>> list = null;
            var apiUrl = !ConnectionChanged ? "pokemon?limit=100&offset=200" : "users?page=2";
            var listKey = !ConnectionChanged ? "results" : "data";
            var response = await _httpClient.GetAsync(apiUrl);
            var content = await response.Content.ReadAsStringAsync();
            Dictionary<string, object> resultObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);

            list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(resultObj[listKey].ToString());
            return list.Where(x => x.FindObject(!ConnectionChanged ? "name" : "first_name", keyword)).ToList();
        }
    }
}
