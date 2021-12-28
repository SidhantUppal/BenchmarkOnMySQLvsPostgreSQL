using MysqlVSPostgresWithReact.Models.API;
using MysqlVSPostgresWithReact.Repositories;
using MySQLVSPostgresWithReact.DataAccessMySQL;
using MySQLVSPostgresWithReact.DataAccessPostgre;
using MySQLVSPostgresWithReact.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLVSPostgresWithReact.Repositories
{
    public class ScopedPassThrough : IScopedPassThrough
    {
        WithMySQLDB withMySQLDB = null;
        WithPostgreDB withPostgreDB = null;

        private readonly MySQLDbContext _mySQLDbContext;
        private readonly PostgreSQLDbContext _postgreSQLDbContext; 

        public ScopedPassThrough(MySQLDbContext mySQLDbContext, PostgreSQLDbContext postgreSQLDbContext)
        {
            _mySQLDbContext = mySQLDbContext;
            withMySQLDB = new WithMySQLDB(_mySQLDbContext);

            _postgreSQLDbContext = postgreSQLDbContext;
            withPostgreDB = new WithPostgreDB(postgreSQLDbContext);
        }

        // get all data
        public async Task<List<TblThread>> GetAllMySQLData() 
        {
            return await withMySQLDB.GetALLData();
        }

        // get all data
        public async Task<List<TblThread>> GetAllPostGreSQLData() 
        {
            return await withPostgreDB.GetALLData();
        }

        // ***** MySQL Operations
        // Save
        public async Task<string> SaveDataInMySQL(TblThread tblThread)
        {
            return await withMySQLDB.SaveData(tblThread); 
        }

        // Select and Update
        public async Task<string> SelectAndUpdateInMySQL()
        {
            return await withMySQLDB.SelectAndUpdate();
        }
        
        // Select, update and Insert
        public async Task<string> SelectUpdateAndInsertMySQL()
        {
            return await withMySQLDB.SelectUpdateAndInsert(); 
        }

        // PostgreSQL Operations
        // Save
        public async Task<string> SaveDataInPostgreSQL(TblThread tblThread)
        {
            return await withPostgreDB.SaveData(tblThread);
        }

        // Select and update
        public async Task<string> SelectAndUpdateInPostgreSQL()
        {
            return await withPostgreDB.SelectAndUpdate();
        }

        // Select, update and Insert
        public async Task<string> SelectUpdateAndInsertPostgreSQL()
        {
            return await withPostgreDB.SelectUpdateAndInsert();
        }
    }
}
