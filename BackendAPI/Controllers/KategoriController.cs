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
        private KategoriBL kategoriBL;

        public KategoriController()
        {
            kategoriBL = new KategoriBL();
        }

        // GET: api/Kategori
        public IEnumerable<Kategori> Get()
        {
            return kategoriBL.GetAll();
        }

        // GET: api/Kategori/5
        public Kategori Get(string id)
        {
            return kategoriBL.GetById(id);
        }

        // POST: api/Kategori
        
        public IHttpActionResult Post(Kategori kategori)
        {
            try
            {
                int result = kategoriBL.Insert(kategori);
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Kategori/5
        public void Put(Kategori kategori)
        {

        }

        // DELETE: api/Kategori/5
        public void Delete(int id)
        {
        }
    }
}
