using BenchmarkDotNet.Attributes;
using MysqlVSPostgresWithReact.Models.API;
using MySQLVSPostgresWithReact.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MySQLVSPostgresWithReact
{
    [MemoryDiagnoser]
    public class Runner
    {
        private static HttpClient client;

        static Runner()
        {
            client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44377/api/");
            //client.BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1/employees");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            LoggedXML.LoggedInXML("Runner() -- END");
        }

        //[Benchmark(Baseline = true)]
        [Benchmark]
        public async Task GetAllMySQLData()
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine("Responce - public async Task GetAllMySQLData() ");
                    HttpResponseMessage response = await client.GetAsync("https://localhost:44377/api/save/TestAPI");
                    
                    //var id = 1;
                    //HttpResponseMessage response = await client.GetAsync("https://localhost:44339/api/studentapi/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(await response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
                catch(Exception ex)
                {
                    LoggedXML.LoggedInXML("Called - Benchmark - GetAllMySQLData " + ex);
                }                
            }
        }

        //[Benchmark] 
        //public async Task GetAllPostgreSQLData()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        try
        //        {
        //            LoggedXML.LoggedInXML("Called - Benchmark - GetAllPostgreSQLData ********* " + i.ToString());

        //            HttpResponseMessage response = await client.GetAsync("https://localhost:44377/api/save/GetAllPostGreSQLData");
        //            //HttpResponseMessage response = await client.GetAsync("http://dummy.restapiexample.com/api/v1/employees");
        //            if (response.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine("Responce - GetAllPostgreSQLData() " + response.RequestMessage);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Internal server Error");
        //            }
        //        }
        //        catch(Exception ex)
        //        {
        //            LoggedXML.LoggedInXML("Called - Benchmark - GetAllPostgreSQLData ********* " + ex.Message);
        //        }
        //    }
        //}

        //[Params(10)]
        //public int iNumRegistries;

        //[Benchmark(Baseline = true)]
        //public async Task<bool> MySQLInsertion()
        //{
        //    for (int i = 0; i < iNumRegistries; i++)
        //    {
        //        HttpResponseMessage response = await client.PostAsJsonAsync("save", new TblThread { Data = i.ToString() });
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine(response.RequestMessage);
        //        }
        //    }

        //    return true;
        //}

        //[Benchmark]
        //public async Task<bool> PGInsertion()
        //{
        //    for (int i = 0; i < iNumRegistries; i++)
        //    {
        //        HttpResponseMessage response = await client.PostAsJsonAsync("save/PGInsertion", new TblThread { Data = i.ToString() });
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine(response.RequestMessage);
        //        }
        //    }

        //    return true;
        //}
    }
}