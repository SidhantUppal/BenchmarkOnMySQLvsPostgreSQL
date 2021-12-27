using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MysqlVSPostgresWithReact.Models.API
{
    public class TblThread
    {
        [Key]
        public int ID { get; set; }
        public string Data { get; set; }
    }
}
