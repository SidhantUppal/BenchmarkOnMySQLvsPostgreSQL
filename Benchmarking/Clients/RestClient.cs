using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Clients
{
    public class RestClient
    {
        private static readonly HttpClient _client;
        static RestClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44377");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAllMySQLData()
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/save");
            string post = "";
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsStringAsync();
                Console.WriteLine(post);
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }

            return post;
        }

        public async Task<string> GetAllPostgreSQLData()
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/save/GetAllPostgreSQLData");
            string post = "";
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsStringAsync();
                Console.WriteLine(post);
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            return post;
        }

        public async Task<string> MySQLInsertion(int iteration)
        {
            return await POSTCallAPI($"/api/save", iteration);
        }

        public async Task<string> PGInsertion(int iteration)
        {
            return await POSTCallAPI($"/api/save/PGInsertion", iteration);
        }

        public async Task<string> MySQLSelectPlusUpdate()
        {
            return await GETCallAPI($"/api/save/MySQLSelectPlusUpdate");
        }

        public async Task<string> PGSelectPlusUpdate()
        {
            return await GETCallAPI($"/api/save/PGSelectPlusUpdate");
        }

        public async Task<string> MySQLSelectPlusUpdatePlusInsertion()
        {
            return await GETCallAPI($"api/save/MySQLcrud");
        }

        public async Task<string> PGSelectPlusUpdatePlusInsertion()
        {
            return await GETCallAPI($"api/save/PGSQLcrud");
        }

        private async Task<string> GETCallAPI(string API)
        {
            Console.WriteLine("private async Task<string> GETCallAPI(string API) " + _client.BaseAddress + API);
            HttpResponseMessage response = await _client.GetAsync(API); 
            string post = "";
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsStringAsync();
                Console.WriteLine(post);
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }

            return post;
        }

        private async Task<string> POSTCallAPI(string API, int iteration)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(API, new TblThread { Data = iteration.ToString() });
            string post = "";
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsStringAsync();
                Console.WriteLine(post);
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }

            return post;
        }
    }
}
