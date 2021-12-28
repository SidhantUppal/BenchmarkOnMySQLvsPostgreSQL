using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Mvc;
using MysqlVSPostgresWithReact.Models.API;
using MySQLVSPostgresWithReact.Interfaces;
using MySQLVSPostgresWithReact.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLVSPostgresWithReact.Controllers
{
    // Save Controller will use to insert, Update operation into the MySQL and Postgres
    [ApiController]
    [Route("api/[controller]")]
    public class SaveController : Controller
    {
        private IScopedPassThrough scopedPassThrough;

        public SaveController(IScopedPassThrough scopedPassThrough)
        {
            this.scopedPassThrough = scopedPassThrough;
        }

        [HttpGet]
        // Get list of mysql data
        public async Task<List<TblThread>> GetAllMySQLData()
        {
            try
            {
                List<TblThread> data = await scopedPassThrough.GetAllMySQLData();
                return data;
            }
            catch (Exception ex)
            {
                LoggedXML.LoggedInXML("Called --- GetAllMySQLData - API " + ex);

                return null;
            }
        }

        // Get list of data from postgres 
        [HttpGet("GetAllPostGreSQLData")]
        public async Task<List<TblThread>> GetAllPostGreSQLData()
        {
            try
            {
                LoggedXML.LoggedInXML("Called --- GetAllPostGreSQLData - API");
                List<TblThread> data = await scopedPassThrough.GetAllPostGreSQLData();
                return data;
            }
            catch (Exception ex)
            {
                LoggedXML.LoggedInXML("Called --- GetAllPostGreSQLData - API " + ex);
                return null;
            }
        }

        [HttpPost]
        // Will insert a registry with a random chain for the string in the MySQL DB
        public async Task<string> MySQLInsertion(TblThread tblThread)
        {
            return await scopedPassThrough.SaveDataInMySQL(tblThread);
        }

        [HttpPost("PGInsertion")]
        // Will insert a registry with a random chain for the string in the PostgreSQL DB
        public async Task<string> PGInsertion(TblThread tblThread)
        {
            return await scopedPassThrough.SaveDataInPostgreSQL(tblThread);
        }

        [HttpGet("MySQLSelectPlusUpdate")]
        // This method will access a random registry using its ID and they will update the string field with a random value (on MySQL DB)
        public async Task<IActionResult> MySQLSelectPlusUpdate()
        {
            return Ok(await scopedPassThrough.SelectAndUpdateInMySQL());
        }

        [HttpGet("PGSelectPlusUpdate")]
        // This method will access a random registry using its ID and they will update the string field with a random value (on PostgreSQL DB)
        public async Task<IActionResult> PGSelectPlusUpdate()
        {
            return Ok(await scopedPassThrough.SelectAndUpdateInPostgreSQL());
        }

        [HttpGet("MySQLcrud")]
        // Method to execute select, update and insertion 
        public async Task<IActionResult> MySQLcrud()
        {
            Console.WriteLine("---------------------------");
            //return Ok(await scopedPassThrough.GetAllPostGreSQLData());

            return Ok(await scopedPassThrough.SelectUpdateAndInsertMySQL());
        }

        [HttpGet("PGSQLcrud")]
        // Method to execute select, update and insertion 
        public async Task<IActionResult> PGSQLcrud()
        { 
            return Ok(await scopedPassThrough.SelectUpdateAndInsertPostgreSQL());
        }
    }
}
