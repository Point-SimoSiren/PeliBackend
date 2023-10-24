using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeliBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string SayHello()
        {
            return ("Hello!");
        }

        // Datan haku menisi näin

        //[HttpGet]
        //public ActionResult GetGames()
        //{
        //    peliDbcontext db = new peliDbcontext();
        //    var pelit = db.Pelit.ToList();
        //    return Ok(pelit);
        //}

    }
}
