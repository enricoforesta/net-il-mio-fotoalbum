using Microsoft.AspNetCore.Mvc;

namespace net_il_mio_fotoalbum.Controllers
{
    public class FotoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public FotoController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /* [HttpPost]
        public IActionResult Create()
        {
            return View();
        }*/

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        /*
        [HttpPost]
        public IActionResult Update()
        {
            return View();
        }*/

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        /*
        [HttpPost]
        public IActionResult Delete()
        {
            return View();
        }*/
    }
}
