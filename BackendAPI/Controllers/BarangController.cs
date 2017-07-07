using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

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
        /// <summary>
        /// Ambil semua data Barang
        /// </summary>
        /// <returns></returns>
       
        public async Task<IEnumerable<Barang>> Get()
        {
            return await barangBL.GetAll();
        }

        // GET: api/Barang/5
        /// <summary>
        /// Ambil data barang berdasarkan id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        [Route("api/Barang/PostUserImage")]
        [HttpPost]
        public string PostUserImage()
        {
            try
            {
                var strRndName = "";
                var httpRequest = HttpContext.Current.Request;
                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 2048 * 2048 * 1; //Size = 4 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");
                            //return BadRequest(message);
                            return message;
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {
                            var message = string.Format("Please Upload a file upto 4 mb.");
                            return message;
                        }
                        else
                        {
                            strRndName = Guid.NewGuid().ToString().Substring(0, 10) + DateTime.Now.Ticks.ToString() + postedFile.FileName;
                            var filePath = HttpContext.Current.Server.MapPath("~/Images/" + strRndName);
                            postedFile.SaveAs(filePath);
                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return strRndName;
                }
                var res = string.Format("Please Upload a image.");
                return res;
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                return res;
            }
        }
    }
}
