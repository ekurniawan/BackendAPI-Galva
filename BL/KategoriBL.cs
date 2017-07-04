
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using DAL;

namespace BL
{
    public class KategoriBL
    {
        private KategoriDAL kategoriDAL;

        public KategoriBL()
        {
            kategoriDAL = new KategoriDAL();
        }

        public IEnumerable<Kategori> GetAll()
        {
            return kategoriDAL.GetAll();
        }

        public Kategori GetById(string id)
        {
            return kategoriDAL.GetById(id);
        }

        public int Insert(Kategori obj)
        {
            if (obj.NamaKategori == "" || obj.NamaKategori == null)
                throw new Exception("Nama Kategori harus diisi !");
            try
            {
                return kategoriDAL.Insert(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Update(Kategori obj)
        {
            if (obj.NamaKategori == "" || obj.NamaKategori == null)
                throw new Exception("Nama Kategori harus diisi !");

            try
            {
                return kategoriDAL.Update(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
