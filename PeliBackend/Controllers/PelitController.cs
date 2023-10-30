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


    // Pelin muokkaaminen eli englanniksi edit (http verbi: put)
    [HttpPut("{id}")]
        public ActionResult EditGame(int id, [FromBody] Pelit muokattuPeli)
        {
            var peli = db.Pelit.Find(id); // haetaan peli tietokannasta käsittelyyn
            if (peli != null)
            {
                // Asetetaan muokatut ominaisuudet olemassa olevaa peliin
                peli.Nimi = muokattuPeli.Nimi;
                peli.Tekijä = muokattuPeli.Tekijä;
                peli.Julkaisuvuosi = muokattuPeli.Julkaisuvuosi;
                peli.GenreId = muokattuPeli.GenreId;

                db.SaveChanges();
                return Ok($"Peli {muokattuPeli.Nimi} on muokattu onnistuneesti."); // string interpolation on toinen
                                                                                                                    // tapa yhdistää
            }                                                                                                     // merkkijonot ja muuttujat
            else
            {
                return NotFound("Peliä id:llä " + id + " ei löytynyt.");
            }
        }

    }
}

