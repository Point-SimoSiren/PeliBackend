using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliBackend.Models;
using System.Reflection.Metadata.Ecma335;

namespace PeliBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PelitController : ControllerBase
    {

       PeliDBContext db = new PeliDBContext();

        // HAKEE KAIKKI PELIT
        [HttpGet]
        public ActionResult Get()
        {
            var pelit = db.Pelit.ToList();
            return Ok(pelit);
        }


        // UUDEN PELIN LISÄÄMINEN

        [HttpPost]
        public ActionResult AddGenre([FromBody] Pelit uusi)
        {
            try
            {
                db.Pelit.Add(uusi);
                db.SaveChanges();
                return Ok("Lisättiin uusi peli:  " + uusi.Nimi);
            }
            catch (Exception e)
            {
                return BadRequest("Virhe. Lue lisää: " + e.InnerException);
            }
        }


        // Hakee pelin genreId:n perusteella
        [HttpGet("/genreid/{genreid}")]
        public ActionResult GetByGenreId(int genreid)
        {
            var pelit = db.Pelit.Where(p => p.GenreId == genreid);
            return Ok(pelit);
        }


        // Haku pelin nimen osalla
        [HttpGet("/name/{hakusana}")]
        public ActionResult GetByName(string hakusana)
        {
            var pelit = db.Pelit.Where(p => p.Nimi.Contains(hakusana)).ToList();

            //var pelit = db.Pelit.Where(p => p.Nimi == hakusana.ToList();

            return Ok(pelit);
        }


        // Pelin poistaminen
        [HttpDelete("{id}")]
        public ActionResult remove(int id)
        {
            var peli = db.Pelit.Find(id);
            if (peli != null)
            {
                db.Pelit.Remove(peli);
                db.SaveChanges();
                return Ok("Peli " + peli.Nimi + " poistettu.");
            }
            else
            {
                return NotFound("Peliä id:llä " + id + " ei löytynyt.");
            }
        }

    }
}

