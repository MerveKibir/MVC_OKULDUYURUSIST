using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace WebApi.Controllers
{
    public class DuyuruController : ApiController
    {
        // GET: Duyuru
        [HttpGet]
        public IEnumerable<Duyuru> DuyuruyuGetir()
        {
            VeriModel model = new VeriModel();
            var liste = model.Duyuru.ToList();
            return liste;
        }
        [HttpPost]
        public IHttpActionResult DuyuruEkle(Duyuru yeniDuyuru)
        {
            VeriModel model = new VeriModel();
            model.Duyuru.Add(yeniDuyuru);
            model.SaveChanges();
            return Ok<string>("Makale eklendi...");
        }
    }
}