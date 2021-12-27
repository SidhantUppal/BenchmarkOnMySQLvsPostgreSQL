using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MysqlVSPostgresWithReact.Models.API;

namespace MySQLVSPostgresWithReact.DataAccessMySQL
{
    public class MySQLDbContext : DbContext 
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options) : base(options) { }


        public virtual DbSet<TblThread> TblThreads { get; set; }
    }
}
