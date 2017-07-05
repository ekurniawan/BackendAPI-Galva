
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

        public async Task<IEnumerable<Kategori>> GetAll()
        {
            return await kategoriDAL.GetAll();
        }

        public async Task<Kategori> GetById(string id)
        {
            return await kategoriDAL.GetById(id);
        }

        

        public async Task<int> Insert(Kategori obj)
        {
            if (obj.NamaKategori == "" || obj.NamaKategori == null)
                throw new Exception("Nama Kategori harus diisi !");
            try
            {
                return await kategoriDAL.Insert(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Update(Kategori obj)
        {
            if (obj.NamaKategori == "" || obj.NamaKategori == null)
                throw new Exception("Nama Kategori harus diisi !");

            try
            {
                return await kategoriDAL.Update(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateMany(List<Kategori> manyKategori)
        {
            try
            {
                foreach (var kategori in manyKategori)
                {
                    await kategoriDAL.Update(kategori);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Delete(Kategori obj)
        {
            Kategori objDel = await kategoriDAL.GetById(obj.KategoriID.ToString());
            if (objDel == null)
                throw new Exception("Kategori tidak ditemukan");

            try
            {
                int result = await kategoriDAL.Delete(obj);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Delete(string id)
        {
            Kategori objDel = await kategoriDAL.GetById(id);
            if (objDel == null)
                throw new Exception("Kategori tidak ditemukan");

            try
            {
                int result = await kategoriDAL.Delete(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteMany(List<string> ids)
        {
            try
            {
                foreach(var id in ids)
                {
                    await kategoriDAL.Delete(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
