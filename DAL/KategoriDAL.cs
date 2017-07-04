using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class KategoriDAL : ICrud<Kategori>
    {
        private string GetConnString()
        {
            return ConfigurationManager.ConnectionStrings["BackendDbConnectionString"]
                .ConnectionString;
        }

        public async Task<int> Delete(Kategori obj)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"delete from Kategori where KategoriID=@KategoriID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@KategoriID", obj.KategoriID);

                try
                {
                    await conn.OpenAsync();
                    int result = await cmd.ExecuteNonQueryAsync();
                    return result;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number.ToString() + " " + sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public async Task<int> Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"delete from Kategori where KategoriID=@KategoriID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@KategoriID", id);

                try
                {
                    await conn.OpenAsync();
                    int result = await cmd.ExecuteNonQueryAsync();
                    return result;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number.ToString() + " " + sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public async Task<IEnumerable<Kategori>> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                List<Kategori> listKategori = new List<Kategori>();
                string strSql = @"select * from Kategori 
                                  order by NamaKategori asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                await conn.OpenAsync();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                if (dr.HasRows)
                {
                    while (await dr.ReadAsync())
                    {
                        Kategori kategori = new Kategori
                        {
                            KategoriID = Convert.ToInt32(dr["KategoriID"].ToString()),
                            NamaKategori = dr["NamaKategori"].ToString()
                        };
                        listKategori.Add(kategori);
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return listKategori;
            }
        }

        
        public async Task<Kategori> GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                Kategori kategori = null;
                string strSql = @"select * from Kategori 
                                  where KategoriID=@KategoriID";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@KategoriID", id);

                await conn.OpenAsync();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                if (dr.HasRows)
                {
                    while (await dr.ReadAsync())
                    {
                        kategori = new Kategori()
                        {
                            KategoriID = Convert.ToInt32(dr["KategoriID"].ToString()),
                            NamaKategori = dr["NamaKategori"].ToString()
                        };
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return kategori;
            }
        }

        public async Task<int> Insert(Kategori obj)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                int result = 0;
                string strSql = @"insert into Kategori(NamaKategori) 
                                  values(@NamaKategori);select @@identity";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@NamaKategori", obj.NamaKategori);
                try
                {
                    await conn.OpenAsync();
                    result = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                    return result;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Number:" + sqlEx.Number.ToString() +
                        " - " + sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }


        public async Task<int> Update(Kategori obj)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"update Kategori set NamaKategori=@NamaKategori 
                              where KategoriID=@KategoriID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@NamaKategori", obj.NamaKategori);
                cmd.Parameters.AddWithValue("@KategoriID", obj.KategoriID);
                try
                {
                    await conn.OpenAsync();
                    int result = await cmd.ExecuteNonQueryAsync();
                    return result;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number.ToString() + " " + sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
    }
}
