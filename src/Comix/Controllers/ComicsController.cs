using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Comix.Models;
using Comix.Models.Base;
using Comix.ViewModels.Comics;
namespace Comix.Controllers
{
    public class ComicsController : Controller
    {
        private ComixDbContext _context;

        public ComicsController(ComixDbContext context)
        {
            _context = context;    
        }

        // GET: Comics
        public async Task<IActionResult> Index()
        {
            var comixDbContext = _context.Comicses.Include(c => c.ParentComics);
            return View(await comixDbContext.ToListAsync());
        }

        // GET: Comics/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comics comics = await _context.Comicses.SingleAsync(m => m.Id == id);
            if (comics == null)
            {
                return HttpNotFound();
            }

            return View(comics);
        }

        // GET: Comics/Create
        public IActionResult Create()
        {
            ViewData["ParentComicsId"] = new SelectList(_context.Comicses, "Id", "ParentComics");
            return View();
        }

        // POST: Comics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comics comics)
        {
            if (ModelState.IsValid)
            {
                _context.Comicses.Add(comics);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ParentComicsId"] = new SelectList(_context.Comicses, "Id", "ParentComics", comics.ParentComicsId);
            return View(comics);
        }

        // GET: Comics/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comics comics = await _context.Comicses.SingleAsync(m => m.Id == id);
            if (comics == null)
            {
                return HttpNotFound();
            }
            ViewData["ParentComicsId"] = new SelectList(_context.Comicses, "Id", "ParentComics", comics.ParentComicsId);
            return View(comics);
        }

        // POST: Comics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Comics comics)
        {
            if (ModelState.IsValid)
            {
                _context.Update(comics);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ParentComicsId"] = new SelectList(_context.Comicses, "Id", "ParentComics", comics.ParentComicsId);
            return View(comics);
        }

        // GET: Comics/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comics comics = await _context.Comicses.SingleAsync(m => m.Id == id);
            if (comics == null)
            {
                return HttpNotFound();
            }

            return View(comics);
        }

        // POST: Comics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            Comics comics = await _context.Comicses.SingleAsync(m => m.Id == id);
            _context.Comicses.Remove(comics);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> ComicsList()
        {
            IList< Comics > list=new List<Comics>() { new Comics() {Id = 10,Title = "Avengers"}, new Comics() { Id = 11, Title = "Batman" }};


            return Json(list);
        }

        public async Task<IActionResult> ComicsKindList()
        {
            IList<ComicsKind> list = new List<ComicsKind>() { new ComicsKind() { Id = 10, Title = "Manga" }, new ComicsKind() { Id = 11, Title = "Comics" } };
            return Json(list);
        }
    }
}
