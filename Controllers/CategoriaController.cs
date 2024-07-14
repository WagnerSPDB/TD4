using Microsoft.AspNetCore.Mvc;
using td4.Models;
using System.Linq;

namespace td4.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }

        public IActionResult CriarCategoria()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarCategoria(CategoriaModel categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public IActionResult EditarCategoria(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public IActionResult EditarCategoria(CategoriaModel categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

      public IActionResult RemoverCategoria(int id)
    {
        var categoria = _context.Categorias.Find(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return View(categoria);
    }

    [HttpPost, ActionName("RemoverCategoria")]
    public IActionResult RemoverCategoriaConfirmed(int id)
    {
        var categoria = _context.Categorias.Find(id);
        if (categoria != null)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
    }
}