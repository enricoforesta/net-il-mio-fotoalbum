using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", CategoriaManager.TutteCategorie());
        }
        [HttpGet]
        public IActionResult Create()
        {
            Categoria categoria = new Categoria();

            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            CategoriaManager.InserisciCategoria(data);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (!CategoriaManager.EliminaCategoria(id))
            {
                return NotFound();
            }
            return RedirectToAction("Index");


        }
    }
}
