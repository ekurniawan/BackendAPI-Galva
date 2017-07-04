
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
        public IEnumerable<Kategori> GetAll()
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            return kategoriDAL.GetAll();
        }
    }
}
