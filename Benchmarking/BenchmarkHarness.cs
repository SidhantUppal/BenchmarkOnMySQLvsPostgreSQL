using BenchmarkDotNet.Attributes;
using Benchmarking.Clients;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking
{
    // Created simple job with
    // warmupCount : 1
    // targetCount : 1
    [SimpleJob(warmupCount: 1, targetCount: 2)]
    public class BenchmarkHarness
    {
        // Set the param as : 1 
        // We can increse the no of Iteration
        [Params(1)]
        public int IterationCount;

        // Initialize the RestClient and object creation
        private readonly RestClient _restClient = new RestClient();

        #region GET API with benchmarking
        //[Benchmark(Baseline = true)]
        //public async Task GetAllMySQLData()
        //{
        //    for (int i = 0; i < IterationCount; i++)
        //    {
        //        await _restClient.GetAllMySQLData();
        //    }
        //}

        //[Benchmark]
        //public async Task GetAllPostgreSQLData()
        //{ 
        //    for (int i = 0; i < IterationCount; i++)
        //    {
        //        await _restClient.GetAllPostgreSQLData();
        //    }
        //}
        #endregion

        #region POST / Insertion API with benchmarking
        // Will insert a registry with a random chain for the string in the MySQL DB
        [Benchmark(Baseline = true)]
        // Set this method : MySQLInsertion as a base of the benchmark execution
        public async Task MySQLInsertion()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                // called the method for interion
                await _restClient.MySQLInsertion(i);
            }
        }

        [Benchmark]
        // Will insert a registry with a random chain for the string in the PostgreSQL DB
        public async Task PGInsertion()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                // called the method for interion
                await _restClient.PGInsertion(i);
            }
        }
        #endregion

        #region PUT / Select and Updation API with benchmarking
        // This method will access a random registry using its ID and they will update the string field with a random value (on MySQL DB)
        [Benchmark]
        public async Task MySQLSelectPlusUpdate()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                // Method for Select and Update 
                await _restClient.MySQLSelectPlusUpdate();
            }
        }

        // This method will access a random registry using its ID and they will update the string field with a random value (on PostgreSQL DB)
        [Benchmark]
        public async Task PGSelectPlusUpdate()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                // Method for Select and Update 
                await _restClient.PGSelectPlusUpdate();
            }
        }
        #endregion

        #region POST / Select Update and Insertion API with benchmarking
        [Benchmark]
        // Method to execute select, update and insertion 
        public async Task MySQLSelectPlusUpdatePlusInsertion()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                // Loogged in the console app
                Console.WriteLine("public async Task MySQLSelectPlusUpdatePlusInsertion()");
                await _restClient.MySQLSelectPlusUpdatePlusInsertion();
            }
        }

        [Benchmark]
        // Method to execute select, update and insertion 
        public async Task PGSelectPlusUpdatePlusInsertion()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                // Loogged in the console app
                Console.WriteLine(" public async Task PGSelectPlusUpdatePlusInsertion");
                await _restClient.PGSelectPlusUpdatePlusInsertion();
            }
        }

        #endregion
    }
}
