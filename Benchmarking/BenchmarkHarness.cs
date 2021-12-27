using BenchmarkDotNet.Attributes;
using Benchmarking.Clients;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking
{
    [SimpleJob(warmupCount: 1, targetCount: 2)]
    public class BenchmarkHarness
    {
        [Params(1)]
        public int IterationCount;

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
        [Benchmark(Baseline = true)]
        public async Task MySQLInsertion()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _restClient.MySQLInsertion(i);
            }
        }

        [Benchmark]
        public async Task PGInsertion()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _restClient.PGInsertion(i);
            }
        }
        #endregion

        #region PUT / Select and Updation API with benchmarking
        //[Benchmark(Baseline = true)]
        [Benchmark]
        public async Task MySQLSelectPlusUpdate()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _restClient.MySQLSelectPlusUpdate();
            }
        }

        [Benchmark]
        public async Task PGSelectPlusUpdate()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _restClient.PGSelectPlusUpdate();
            }
        }
        #endregion

        #region POST / Select Update and Insertion API with benchmarking
        //[Benchmark(Baseline = true)]
        [Benchmark]
        public async Task MySQLSelectPlusUpdatePlusInsertion()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                Console.WriteLine("public async Task MySQLSelectPlusUpdatePlusInsertion()");

                await _restClient.MySQLSelectPlusUpdatePlusInsertion();
            }
        }

        [Benchmark]
        public async Task PGSelectPlusUpdatePlusInsertion()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _restClient.PGSelectPlusUpdatePlusInsertion();
            }
        }

        #endregion
    }
}
