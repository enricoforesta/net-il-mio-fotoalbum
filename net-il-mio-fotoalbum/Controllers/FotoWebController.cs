using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;

namespace net_il_mio_fotoalbum.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FotoWebController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult MostraFoto(string? name)
        {
            if(name == null) return Ok(FotoManager.TutteFoto());
            return Ok(FotoManager.TutteFoto().Where(f => f.Titolo.ToLower().Contains(name.ToLower())));
        }
    }
}
