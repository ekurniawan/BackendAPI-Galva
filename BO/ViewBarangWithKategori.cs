using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ViewBarangWithKategori
    {
        public string BarangID { get; set; }
        public int KategoriID { get; set; }
        public string NamaKategori { get; set; }
        public string NamaBarang { get; set; }
        public string Deskripsi { get; set; }
        public int Stok { get; set; }
        public decimal HargaBeli { get; set; }
        public decimal HargaJual { get; set; }
        public string Gambar { get; set; }
    }
}
