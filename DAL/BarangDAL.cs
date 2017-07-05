using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace DAL
{
    public class BarangDAL : ICrud<Barang>
    {
        private string GetConnString()
        {
            return ConfigurationManager.ConnectionStrings["BackendDbConnectionString"]
                .ConnectionString;
        }

        public Task<int> Delete(Barang obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Barang>> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from Barang order by NamaBarang asc";
                return await conn.QueryAsync<Barang>(strSql);
            }
        }

        /*public async Task<IEnumerable<ViewBarangWithKategori>> GetAllWithKategori()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from ViewBarangWithKategori order by NamaBarang asc";
                return await conn.QueryAsync<ViewBarangWithKategori>(strSql);
            }
        }*/

        public async Task<IEnumerable<Barang>> GetAllWithKategori()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"SELECT * FROM Barang LEFT JOIN Kategori 
                                  ON Barang.KategoriID = dbo.Kategori.KategoriID";
                var results = await conn.QueryAsync<Barang, Kategori, Barang>(strSql,
                    (b, k) =>
                    {
                        b.Kategori = k;
                        return b;
                    }, splitOn: "KategoriID");

                return results;
            }
        }

        public async Task<Barang> GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from Barang where BarangID=@BarangID";
                var param = new { BarangID = id };
                var result = await conn.QuerySingleOrDefaultAsync<Barang>(strSql,
                    param);
                return result;
            }
        }

        public Task<int> Insert(Barang obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Barang obj)
        {
            throw new NotImplementedException();
        }

      

       
    }
}
