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

        public int Delete(Kategori obj)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"delete from Kategori where KategoriID=@KategoriID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@KategoriID", obj.KategoriID);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
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

        public int Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"delete from Kategori where KategoriID=@KategoriID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@KategoriID", id);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
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

        public IEnumerable<Kategori> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                List<Kategori> listKategori = new List<Kategori>();
                string strSql = @"select * from Kategori 
                                  order by NamaKategori asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
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

        
        public Kategori GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                Kategori kategori = null;
                string strSql = @"select * from Kategori 
                                  where KategoriID=@KategoriID";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@KategoriID", id);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
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

        public int Insert(Kategori obj)
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
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
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


        public int Update(Kategori obj)
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
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
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
