using Microsoft.AspNetCore.Mvc;
using td4.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace td4.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarefaController(ApplicationDbContext context)
        { 
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }

        public IActionResult CriarTarefa()
        {
            var categorias = _context.Categorias.ToList();
            ViewBag.Categorias = new SelectList(categorias, "Nome", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult CriarTarefa(TarefaModel tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var categorias = _context.Categorias.ToList();
            ViewBag.Categorias = new SelectList(categorias, "Nome", "Nome");
            return View(tarefa);
        }

        public IActionResult EditarTarefa(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            var categorias = _context.Categorias.ToList();
            ViewBag.Categorias = new SelectList(categorias, "Nome", "Nome");
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult EditarTarefa(TarefaModel tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Update(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var categorias = _context.Categorias.ToList();
            ViewBag.Categorias = new SelectList(categorias, "Nome", "Nome");
            return View(tarefa);
        }

        public IActionResult RemoverTarefa(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        [HttpPost, ActionName("RemoverTarefa")]
        public IActionResult RemoverTarefaConfirmed(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
