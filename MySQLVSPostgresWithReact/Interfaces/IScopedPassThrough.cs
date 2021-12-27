using MysqlVSPostgresWithReact.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLVSPostgresWithReact.Interfaces
{
    public interface IScopedPassThrough
    {
        Task<List<TblThread>> GetAllMySQLData();
        Task<List<TblThread>> GetAllPostGreSQLData();
        Task<string> SaveDataInMySQL(TblThread tblThread);
        Task<string> SaveDataInPostgreSQL(TblThread tblThread);
        Task<string> SelectUpdateAndInsertMySQL();
        Task<string> SelectUpdateAndInsertPostgreSQL();

        Task<string> SelectAndUpdateInMySQL();
        Task<string> SelectAndUpdateInPostgreSQL();
    }
}
