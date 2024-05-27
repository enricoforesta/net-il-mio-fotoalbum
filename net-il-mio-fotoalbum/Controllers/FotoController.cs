using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;

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
            return View(FotoManager.TutteFoto());
        }
        public IActionResult Details(int id)
        {
            var foto = FotoManager.CercaPerId(id);
            if (foto == null)
                return NotFound();
            return View(foto);
        }
        [HttpGet]
        public IActionResult Create()
        {
            FotoFormModel model = new FotoFormModel(new Foto(), FotoFormModel.CreaCategorie() );
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FotoFormModel data)
        {
            if (!ModelState.IsValid)
            {
                data.Categorie = FotoFormModel.CreaCategorie();
                data.SetImage();
                return View(data);
            }
            data.SetImage();
            FotoManager.InserisciFoto(data.Foto, data.SelezionaCategorie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var fotoDaModificare = FotoManager.CercaPerId(id);
            if (fotoDaModificare == null)
                return NotFound();
            FotoFormModel model = new FotoFormModel(fotoDaModificare, FotoFormModel.CreaCategorie());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, FotoFormModel data)
        {
            if (!ModelState.IsValid)
            {
                data.Categorie = FotoFormModel.CreaCategorie();
                data.SetImage();
                return View(data);
            }

            if (!FotoManager.ModificaFoto(id, data.Foto.Titolo, data.Foto.Descrizione, data.Foto.Visibile, data.SelezionaCategorie, data.SetImage()))
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (!FotoManager.EliminaFoto(id))
                return NotFound();
            return RedirectToAction("Index");
        }
    }
}
