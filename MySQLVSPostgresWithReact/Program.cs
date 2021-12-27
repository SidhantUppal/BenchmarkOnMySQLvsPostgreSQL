using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MysqlVSPostgresWithReact.Models.API;
using MysqlVSPostgresWithReact.Repositories;
using MySQLVSPostgresWithReact.Controllers;
using MySQLVSPostgresWithReact.DataAccessMySQL;
using MySQLVSPostgresWithReact.DataAccessPostgre;
using MySQLVSPostgresWithReact.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MySQLVSPostgresWithReact
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //LoggedXML.LoggedInXML("Called --- BenchmarkRunner.Run<Runner>()");

            //BenchmarkRunner.Run<Runner>();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    // *************** NOT USING NOW *****************
    //[MemoryDiagnoser]
    public class BenchmarkonMySQLvsPostgreSQL
    {
        private readonly MySQLDbContext _mySQLDbContext;
        private readonly PostgreSQLDbContext _postgreSQLDbContext;

        WithMySQLDB withMySQLDB = null;
        WithPostgreDB withPostgreDB = null;

        public BenchmarkonMySQLvsPostgreSQL(MySQLDbContext mySQLDbContext, PostgreSQLDbContext postgreSQLDbContext)
        {
            Console.WriteLine("*********** BenchmarkonMySQLvsPostgreSQL start *********");

            _mySQLDbContext = mySQLDbContext;
            withMySQLDB = new WithMySQLDB(_mySQLDbContext);


            _postgreSQLDbContext = postgreSQLDbContext;
            withPostgreDB = new WithPostgreDB(postgreSQLDbContext);

            Console.WriteLine("*********** BenchmarkonMySQLvsPostgreSQL end *********");
        }

        [Benchmark(Baseline = true)]
        public async Task<bool> MySQLInsertion()
        {
            Console.WriteLine("*********** MySQLInsertion *********");
            bool flag = false;
            for (int i = 0; i < 100; i++)
            {
                List<TblThread> data = await withMySQLDB.GetALLData();
                flag = !flag;
                Console.WriteLine("*********** MySQLInsertion() -- Count *********");
            }
            return flag;
        }

        [Benchmark]
        public async Task<bool> PGInsertion()
        {
            Console.WriteLine("*********** PGInsertion *********");

            bool flag = false;
            for (int i = 0; i < 100; i++)
            {
                List<TblThread> data = await withPostgreDB.GetALLData();
                flag = !flag;
                Console.WriteLine("*********** PGInsertion() -- Count *********");
            }
            return flag;
        }
    }
}
