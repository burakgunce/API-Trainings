using HastaneApi.Context;
using HastaneApi.Entities;
using HastaneApi.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastanelerController : ControllerBase
    {
        //public HastanelerController()
        //{
        //    db = new HastaneDbContext();
        //}
        //HastaneDbContext db;

        private readonly HastaneDbContext db;

        public HastanelerController(HastaneDbContext _db)
        {
            db = _db;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() //IAction result kullanırsan onun ıstedıgı ok bad request gıbı seylerın ıcıne yaz
        {
            return Ok(db.Hastaneler.ToList());
        }

        [HttpGet("getbyid")]
        public ActionResult Get(int id) // actıon result kullanırsan donen tıpı belırt (belırtırsen ok falan message larını kullanmana gerek yok) veya belirtmeden yapıp ok bad request kullanmalısın
        {
            return Ok(db.Hastaneler.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost("Add")]
        public ActionResult Add(HastaneAddDTO hastanedto)
        {
            Hastane hastane = new Hastane();
            hastane.HastaneAd = hastanedto.Name;
            hastane.HastaneAdres = hastanedto.Adres;
            db.Add(hastane);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult Update(int id, HastaneAddDTO hastanedto)
        {
            Hastane hastane = db.Hastaneler.FirstOrDefault(x => x.Id == id);
            hastane.HastaneAd = hastanedto.Name;
            hastane.HastaneAdres = hastanedto.Adres;
            db.Update(hastane);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            Hastane hastane = db.Hastaneler.Find(id);
            db.Remove(hastane);
            db.SaveChanges();
            return Ok();
        }


    }
}
