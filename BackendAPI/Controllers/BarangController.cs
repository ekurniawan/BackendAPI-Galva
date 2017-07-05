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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Barang
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Barang/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Barang/5
        public void Delete(int id)
        {
        }
    }
}
