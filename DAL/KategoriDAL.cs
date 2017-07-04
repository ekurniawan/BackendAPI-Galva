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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public int Insert(Kategori obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Kategori obj)
        {
            throw new NotImplementedException();
        }
    }
}
