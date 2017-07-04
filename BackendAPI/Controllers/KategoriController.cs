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
    public class KategoriController : ApiController
    {
        private KategoriBL kategoriBL;

        public KategoriController()
        {
            kategoriBL = new KategoriBL();
        }

        // GET: api/Kategori
        public async Task<IEnumerable<Kategori>> Get()
        {
            return await kategoriBL.GetAll();
        }

        // GET: api/Kategori/5
        public async Task<Kategori> Get(string id)
        {
            return await kategoriBL.GetById(id);
        }

        // POST: api/Kategori
        
        public async Task<IHttpActionResult> Post(Kategori kategori)
        {
            try
            {
                int result = await kategoriBL.Insert(kategori);
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Kategori/5
        public async Task<IHttpActionResult> Put(Kategori kategori)
        {
            try
            {
                int result = await kategoriBL.Update(kategori);
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Kategori/UpdateMany")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateMany(List<Kategori> listKategori)
        {
            try
            {
                await kategoriBL.UpdateMany(listKategori);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Kategori/5
        public async Task<IHttpActionResult> Delete(Kategori kategori)
        {
            try
            {
                int result = await kategoriBL.Delete(kategori);
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IHttpActionResult> Delete(string id)
        {
            try
            {
                int result = await kategoriBL.Delete(id);
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Kategori/DeleteMany")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteMany(List<string> ids)
        {
            try
            {
                await kategoriBL.DeleteMany(ids);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
