using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Models;

namespace TestProject.Core.services
{
  public  class APIService
    {
        private HttpClient client;

        public APIService()
        {
            client = new HttpClient();
        }

        public async Task<List<TaskInfo>> RefreshDataAsync()
        {
            
            // RestUrl = http://developer.xamarin.com:8081/api/todoitems/
            var uri = new Uri(string.Format("http://localhost:58778", string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var _tasks = JsonConvert.DeserializeObject<List<TaskInfo>>(content);
                
            };
            return null;
        }
    }
}

