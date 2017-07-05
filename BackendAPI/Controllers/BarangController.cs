using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BO;
using BL;
using System.Threading.Tasks;

namespace BackendAPI.Controllers
{
    public class BarangController : ApiController
    {
        private BarangBL barangBL;

        public BarangController()
        {
            barangBL = new BarangBL();
        }

        // GET: api/Barang
        public async Task<IEnumerable<Barang>> Get()
        {
            return await barangBL.GetAll();
        }

        // GET: api/Barang/5
        public async Task<Barang> Get(string id)
        {
            return await barangBL.GetById(id);
        }

        // POST: api/Barang
        public async Task<IHttpActionResult> Post(Barang barang)
        {
            int result = await barangBL.Insert(barang);
            if (result != -1)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Gagal tambah data barang !");
            }
        }

        // PUT: api/Barang/5
        public async Task<IHttpActionResult> Put(Barang barang)
        {
            int result = await barangBL.Update(barang);
            if (result != -1)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Gagal update data barang !");
            }
        }

        // DELETE: api/Barang/5
        public async Task<IHttpActionResult> Delete(Barang barang)
        {
            int result = await barangBL.Delete(barang);
            if (result != -1)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Gagal delete data barang !");
            }
        }
    }
}
