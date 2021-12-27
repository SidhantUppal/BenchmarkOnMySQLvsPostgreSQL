//using Dapper;
using MySql.Data.MySqlClient;
using MysqlVSPostgresWithReact.Models.API;
using MySQLVSPostgresWithReact.DataAccessMySQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysqlVSPostgresWithReact.Repositories
{
    public class WithMySQLDB
    {
        private readonly MySQLDbContext _context;

        public WithMySQLDB(MySQLDbContext context)
        {
            _context = context;
        }

        public async Task<List<TblThread>> GetALLData()
        {
            Console.WriteLine("*********** GetALLData START *********");

            List<TblThread> data = null;

            await Task.Run(() =>
            {
                data = _context.TblThreads.ToList();
            });

            Console.WriteLine("*********** GetALLData END *********");
            return data;
        }

        public async Task<string> SaveData(TblThread tblThread)
        {
            return await Save(tblThread);
        }

        public async Task<string> SelectAndUpdate()
        {
            string done = "";
            try
            {
                // Select all the data from database
                List<TblThread> allTblThreads = await Select();

                foreach (TblThread tblThread in allTblThreads)
                {
                    await Update(tblThread);
                }

                done = "Data are saved in MySQLDB";
            }
            catch (Exception ex)
            {
                done = ex.Message;
            }
            return done;
        }

        public async Task<string> SelectUpdateAndInsert()
        {
            string done = "";
            try
            {
                List<TblThread> allTblThreads = await Select();
                Console.WriteLine(allTblThreads);

                foreach (TblThread tblThread in allTblThreads)
                {
                    await Update(tblThread);

                    await Save(new TblThread { Data = "Again - New - " + tblThread.ID });
                }

                done = "Data are saved in MySQLDB";
            }
            catch (Exception ex)
            {
                done = ex.Message;
            }
            return done;
        }

        // ****** All privates methods here *******
        private async Task<string> Save(TblThread tblThread)
        {
            string done = "";
            try
            {
                await Task.Run(() =>
                {
                    // Add
                    Console.WriteLine("*********** Add / Insert data *********");
                    _context.TblThreads.Add(tblThread);

                    if (_context.SaveChanges() == 1)
                    {
                        done = "Data are saved in MySQLDB";
                    }
                });
            }
            catch (Exception ex)
            {
                done = ex.Message;
            }
            return done;
        }

        private async Task<bool> Update(TblThread tblThread)
        {
            bool result = false;
            await Task.Run(() =>
            {
                // Update
                Console.WriteLine("*********** Update data *********");
                _context.Entry(tblThread).CurrentValues.SetValues(new TblThread { ID = tblThread.ID, Data = "Updated - " + tblThread.ID + " - " + DateTime.Now.ToString("hh:mm:ss") });
                _context.SaveChanges();
            });

            return result;
        }

        private async Task<List<TblThread>> Select()
        {
            List<TblThread> allTblThreads = null;
            Console.WriteLine(" private async Task<List<TblThread>> Select()");

            try
            {
                await Task.Run(() =>
                {
                    allTblThreads = _context.TblThreads.ToList();
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(" private async Task<List<TblThread>> Select() --- " + ex.Message);
            }

            return allTblThreads;
        }
    }
}
