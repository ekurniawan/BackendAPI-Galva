using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using DAL;

namespace BL
{
    public class BarangBL
    {
        private BarangDAL barangDAL;

        public BarangBL()
        {
            barangDAL = new BarangDAL();
        }

        public async Task<IEnumerable<Barang>> GetAll()
        {
            return await barangDAL.GetAll();
        }

        public async Task<IEnumerable<Barang>> GetAllWithKategori()
        {
            return await barangDAL.GetAllWithKategori();
        }

        public async Task<int> Insert(Barang obj)
        {
            return await barangDAL.Insert(obj);
        }

        public async Task<int> Update(Barang obj)
        {
            return await barangDAL.Update(obj);
        }

        public async Task<int> Delete(Barang obj)
        {
            return await barangDAL.Delete(obj);
        }

        public async Task<Barang> GetById(string id)
        {
            return await barangDAL.GetById(id);
        }
    }
}
