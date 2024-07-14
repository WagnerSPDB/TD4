using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using td4.Models;

namespace td4.Controllers
{
    public class ListaDeTarefasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaDeTarefasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaDeTarefas = _context.ListaDeTarefas.ToList();
            return View(listaDeTarefas);
        }

        public IActionResult AdicionarTarefaNaLista()
        {
            var tarefas = _context.Tarefas.ToList();
            ViewBag.Tarefas = new SelectList(tarefas, "Nome", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarTarefaNaLista(ListaDeTarefasModel model)
        {
            if (ModelState.IsValid)
            {
                _context.ListaDeTarefas.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var tarefas = _context.Tarefas.ToList();
            ViewBag.Tarefas = new SelectList(tarefas, "Nome", "Nome");
            return View(model);
        }

        public IActionResult EditarTarefaNaLista(int id)
        {
            var lista = _context.ListaDeTarefas.Find(id);
            if (lista == null)
            {
                return NotFound();
            }
            var tarefas = _context.Tarefas.ToList();
            ViewBag.Tarefas = new SelectList(tarefas, "Nome", "Nome");
            return View(lista);
        }

        [HttpPost]
        public IActionResult EditarTarefaNaLista(ListaDeTarefasModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var tarefas = _context.Tarefas.ToList();
            ViewBag.Tarefas = new SelectList(tarefas, "Nome", "Nome");
            return View(model);
        }

        public IActionResult RemoverTarefaDaLista(int id)
        {
            var lista = _context.ListaDeTarefas.Find(id);
            if (lista == null)
            {
                return NotFound();
            }
            var tarefas = _context.Tarefas.ToList();
            ViewBag.Tarefas = new SelectList(tarefas, "Nome", "Nome");
            return View(lista);
        }

        [HttpPost, ActionName("RemoverTarefa")]
        public IActionResult RemoverTarefaConfirmed(int id)
        {
            var lista = _context.ListaDeTarefas.Find(id);
            if (lista != null)
            {
                _context.ListaDeTarefas.Remove(lista);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
