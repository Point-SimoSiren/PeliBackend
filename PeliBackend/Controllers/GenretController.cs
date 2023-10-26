using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliBackend.Models;

namespace GenreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenretController : ControllerBase
    {
        PeliDBContext db = new PeliDBContext();

        // Metodi joka hakee kaikki Genret
        [HttpGet]
        public ActionResult GetAllGenres()
        {
            var Genret = db.Genret.ToList();

            return Ok(Genret);

        }

        // UUDEN Genren LISÄÄMINEN

        [HttpPost]
        public ActionResult AddGame([FromBody] Genret uusiGenre)
        {

            try
            {
                db.Genret.Add(uusiGenre);
                db.SaveChanges();
                return Ok("Lisättiin uusi Genre " + uusiGenre.Genre);
            }
            catch (Exception e)
            {
                return BadRequest("Virhe. Lue lisää: " + e.InnerException);
            }
        }
    }
}
