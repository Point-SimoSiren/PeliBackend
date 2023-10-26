using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliBackend.Models;

namespace PeliBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PelitController : ControllerBase
    {
        PeliDBContext db = new PeliDBContext();

        // Metodi joka hakee kaikki pelit
        [HttpGet]
        public ActionResult GetAllGames() {
            var pelit = db.Pelit.ToList();

            return Ok(pelit);

        }

        // UUDEN PELIN LISÄÄMINEN

        [HttpPost]
        public ActionResult AddGame([FromBody] Pelit uusiPeli) {
            
            db.Pelit.Add(uusiPeli);
            db.SaveChanges();
            return Ok("Lisättiin uusi peli " + uusiPeli.Nimi);
        }

        // Haku pelin nimen osalla
        [HttpGet("/name/{hakusana}")]
        public ActionResult GetByName(string hakusana)
        {
            var pelit = db.Pelit.Where(p => p.Nimi.Contains(hakusana)).ToList();

            //var pelit = db.Pelit.Where(p => p.Nimi == hakusana.ToList();

            return Ok(pelit);
        }


    }
}

