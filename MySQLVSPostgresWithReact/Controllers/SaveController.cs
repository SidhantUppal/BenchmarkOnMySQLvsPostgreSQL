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
        public async Task<string> MySQLInsertion(TblThread tblThread)
        {
            return await scopedPassThrough.SaveDataInMySQL(tblThread);
        }

        [HttpPost("PGInsertion")]
        public async Task<string> PGInsertion(TblThread tblThread)
        {
            return await scopedPassThrough.SaveDataInPostgreSQL(tblThread);
        }


        [HttpGet("MySQLSelectPlusUpdate")]
        public async Task<IActionResult> MySQLSelectPlusUpdate()
        {
            return Ok(await scopedPassThrough.SelectAndUpdateInMySQL());
        }

        [HttpGet("PGSelectPlusUpdate")]
        public async Task<IActionResult> PGSelectPlusUpdate()
        {
            return Ok(await scopedPassThrough.SelectAndUpdateInPostgreSQL());
        }


        [HttpGet("MySQLcrud")]
        public async Task<IActionResult> MySQLcrud()
        {
            Console.WriteLine("---------------------------");
            //return Ok(await scopedPassThrough.GetAllPostGreSQLData());

            return Ok(await scopedPassThrough.SelectUpdateAndInsertMySQL());
        }

        [HttpGet("PGSQLcrud")]
        public async Task<IActionResult> PGSQLcrud()
        { 
            return Ok(await scopedPassThrough.SelectUpdateAndInsertPostgreSQL());
        }
    }
}
