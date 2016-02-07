using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Comix.Models;
using Comix.Models.Base;

namespace Comix.Controllers
{
    public class ComicsPersonsController : Controller
    {
        private ComixDbContext _context;

        public ComicsPersonsController(ComixDbContext context)
        {
            _context = context;    
        }

        // GET: ComicsPersons
        public async Task<IActionResult> Index()
        {
            
             var comixDbContext = _context.ComicsPersons.Include(c => c.Comics).Include(c => c.Person).Include(c => c.PersonType);
            return View(await comixDbContext.ToListAsync());
        }

        // GET: ComicsPersons/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ComicsPerson comicsPerson = await _context.ComicsPersons.SingleAsync(m => m.ComicsId == id);
            if (comicsPerson == null)
            {
                return HttpNotFound();
            }

            return View(comicsPerson);
        }

        // GET: ComicsPersons/Create
        public IActionResult Create()
        {
            ViewData["ComicsId"] = new SelectList(_context.Comicses, "Id", "Comics");
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Person");
            ViewBag.Category = new SelectList(_context.PersonTypes, "Id", "Title");
            return View();
        }

        // POST: ComicsPersons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComicsPerson comicsPerson)
        {
            if (ModelState.IsValid)
            {
                _context.ComicsPersons.Add(comicsPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ComicsId"] = new SelectList(_context.Comicses, "Id", "Comics", comicsPerson.ComicsId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Person", comicsPerson.PersonId);
            ViewData["PersonTypeId"] = new SelectList(_context.PersonTypes, "Id", "PersonType", comicsPerson.PersonTypeId);
            return View(comicsPerson);
        }

        // GET: ComicsPersons/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ComicsPerson comicsPerson = await _context.ComicsPersons.SingleAsync(m => m.ComicsId == id);
            if (comicsPerson == null)
            {
                return HttpNotFound();
            }
            ViewData["ComicsId"] = new SelectList(_context.Comicses, "Id", "Comics", comicsPerson.ComicsId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Person", comicsPerson.PersonId);
            ViewData["PersonTypeId"] = new SelectList(_context.PersonTypes, "Id", "PersonType", comicsPerson.PersonTypeId);
            return View(comicsPerson);
        }

        // POST: ComicsPersons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ComicsPerson comicsPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Update(comicsPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ComicsId"] = new SelectList(_context.Comicses, "Id", "Comics", comicsPerson.ComicsId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Person", comicsPerson.PersonId);
            ViewData["PersonTypeId"] = new SelectList(_context.PersonTypes, "Id", "PersonType", comicsPerson.PersonTypeId);
            return View(comicsPerson);
        }

        // GET: ComicsPersons/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ComicsPerson comicsPerson = await _context.ComicsPersons.SingleAsync(m => m.ComicsId == id);
            if (comicsPerson == null)
            {
                return HttpNotFound();
            }

            return View(comicsPerson);
        }

        // POST: ComicsPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            ComicsPerson comicsPerson = await _context.ComicsPersons.SingleAsync(m => m.ComicsId == id);
            _context.ComicsPersons.Remove(comicsPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
