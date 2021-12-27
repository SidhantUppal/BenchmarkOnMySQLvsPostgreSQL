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
        // Initialize HttpClient
        private static readonly HttpClient _client;
        static RestClient()
        {
            // Update HttpClient
            _client = new HttpClient();

            // Set API server
            _client.BaseAddress = new Uri("https://localhost:44377");

            // Set http headers
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Get all data from MySQL database
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

        // Get all data from PostgreSQL database
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

        // Insert records in MySQL database into the tblThread 
        public async Task<string> MySQLInsertion(int iteration)
        {
            return await POSTCallAPI($"/api/save", iteration);
        }

        // Insert records in PostgreSQL database into the tblThread 
        public async Task<string> PGInsertion(int iteration)
        {
            return await POSTCallAPI($"/api/save/PGInsertion", iteration);
        }

        // Select all records from the db and update records in MySQL database 
        public async Task<string> MySQLSelectPlusUpdate()
        {
            return await GETCallAPI($"/api/save/MySQLSelectPlusUpdate");
        }

        // Select all records from the db and update records in PostgreSQL database 
        public async Task<string> PGSelectPlusUpdate()
        {
            return await GETCallAPI($"/api/save/PGSelectPlusUpdate");
        }

        // Select all records from the db the update and then Insert records in MySQL database 
        public async Task<string> MySQLSelectPlusUpdatePlusInsertion()
        {
            return await GETCallAPI($"api/save/MySQLcrud");
        }

        // Select all records from the db the update and then Insert records in PostgreSQL database 
        public async Task<string> PGSelectPlusUpdatePlusInsertion()
        {
            return await GETCallAPI($"api/save/PGSQLcrud");
        }


        // This are the privatre method called inside that class only
        // GET Call API
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

        // POST Call API
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
