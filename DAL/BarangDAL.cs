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

        public async Task<int> Delete(Barang obj)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                int result = 0;
                string strSql = "delete from Barang where BarangID=@BarangID";
                try
                {
                    var param = new
                    {
                        BarangID = obj.BarangID
                    };
                    result = await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Number:" + sqlEx.Number.ToString() + " " +
                        sqlEx.Message);
                }
                return result;
            }
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

        public async Task<int> Insert(Barang obj)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                int result=0;
                string strSql = "insert into Barang(BarangID,KategoriID,NamaBarang,Deskripsi,Stok,HargaBeli,HargaJual,Gambar) " +
                "values(@BarangID,@KategoriID,@NamaBarang,@Deskripsi,@Stok,@HargaBeli,@HargaJual,@Gambar)";
                try
                {
                    var param = new
                    {
                        BarangID = obj.BarangID,
                        KategoriID = obj.KategoriID,
                        NamaBarang = obj.NamaBarang,
                        Deskripsi = obj.Deskripsi,
                        Stok = obj.Stok,
                        HargaBeli = obj.HargaBeli,
                        HargaJual = obj.HargaJual,
                        Gambar = obj.Gambar
                    };
                    result = await conn.ExecuteAsync(strSql,param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Number:" + sqlEx.Number.ToString() + " " +
                        sqlEx.Message);
                }
                return result;
            }
        }

        

        public async Task<int> Update(Barang obj)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                int result = 0;
                string strSql = @"update Barang set KategoriID=@KategoriID,NamaBarang=@NamaBarang,
                    Deskripsi=@Deskripsi,Stok=@Stok,HargaBeli=@HargaBeli,
                    HargaJual=@HargaJual,Gambar=@Gambar where BarangID=@BarangID";
                try
                {
                    var param = new
                    {
                        BarangID = obj.BarangID,
                        KategoriID = obj.KategoriID,
                        NamaBarang = obj.NamaBarang,
                        Deskripsi = obj.Deskripsi,
                        Stok = obj.Stok,
                        HargaBeli = obj.HargaBeli,
                        HargaJual = obj.HargaJual,
                        Gambar = obj.Gambar
                    };
                    result = await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Number:" + sqlEx.Number.ToString() + " " +
                        sqlEx.Message);
                }
                return result;
            }
        }

      

       
    }
}
