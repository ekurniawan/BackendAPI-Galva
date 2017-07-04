using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Dapper;

namespace DAL
{
    public class BarangDAL : ICrud<Barang>
    {
        private string GetConnString()
        {
            return ConfigurationManager.ConnectionStrings["BackendDbConnectionString"]
                .ConnectionString;
        }

        public int Delete(Barang obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Barang> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from Barang order by NamaBarang asc";
                return conn.Query<Barang>(strSql);
            }
        }

        public Barang GetById(string id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Barang obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Barang obj)
        {
            throw new NotImplementedException();
        }
    }
}
