using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOP3;
using OOP3.Models;

namespace OOP3.Controllers
{
    public class GroupasController : Controller
    {
        private readonly ApplicationContext _context;

        public GroupasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Groupas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Groups.ToListAsync());
        }

        // GET: Groupas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupa = await _context.Groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupa == null)
            {
                return NotFound();
            }

            return View(groupa);
        }

        // GET: Groupas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groupas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Groupa groupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupa);
        }

        // GET: Groupas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupa = await _context.Groups.FindAsync(id);
            if (groupa == null)
            {
                return NotFound();
            }
            return View(groupa);
        }

        // POST: Groupas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Groupa groupa)
        {
            if (id != groupa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupaExists(groupa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(groupa);
        }

        // GET: Groupas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupa = await _context.Groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupa == null)
            {
                return NotFound();
            }

            return View(groupa);
        }

        // POST: Groupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupa = await _context.Groups.FindAsync(id);
            if (groupa != null)
            {
                _context.Groups.Remove(groupa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupaExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
