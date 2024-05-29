using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecensioneWebController : ControllerBase
    {
        [HttpPost]
        public IActionResult NuovaRecensione([FromBody] Recensione recensione)
        {
            RecensioneManager.InserisciRecensione(recensione);
            return Ok();
        }
    }
}
