using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BO;
using BL;

namespace BackendAPI.Controllers
{
    public class KategoriController : ApiController
    {
        // GET: api/Kategori
        public IEnumerable<Kategori> Get()
        {
            KategoriBL kategoriBL = new KategoriBL();
            return kategoriBL.GetAll();
        }

        // GET: api/Kategori/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Kategori
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Kategori/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Kategori/5
        public void Delete(int id)
        {
        }
    }
}
