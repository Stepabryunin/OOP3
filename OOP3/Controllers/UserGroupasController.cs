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
    public class UserGroupasController : Controller
    {
        private readonly ApplicationContext _context;

        public UserGroupasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: UserGroupas
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.UserGroups.Include(u => u.User);
            return View(await applicationContext.ToListAsync());
        }

        // GET: UserGroupas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGroupa = await _context.UserGroups
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userGroupa == null)
            {
                return NotFound();
            }

            return View(userGroupa);
        }

        // GET: UserGroupas/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserGroupas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,GroupID")] UserGroupa userGroupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userGroupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", userGroupa.UserID);
            return View(userGroupa);
        }

        // GET: UserGroupas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGroupa = await _context.UserGroups.FindAsync(id);
            if (userGroupa == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", userGroupa.UserID);
            return View(userGroupa);
        }

        // POST: UserGroupas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,GroupID")] UserGroupa userGroupa)
        {
            if (id != userGroupa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userGroupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserGroupaExists(userGroupa.Id))
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", userGroupa.UserID);
            return View(userGroupa);
        }

        // GET: UserGroupas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGroupa = await _context.UserGroups
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userGroupa == null)
            {
                return NotFound();
            }

            return View(userGroupa);
        }

        // POST: UserGroupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userGroupa = await _context.UserGroups.FindAsync(id);
            if (userGroupa != null)
            {
                _context.UserGroups.Remove(userGroupa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserGroupaExists(int id)
        {
            return _context.UserGroups.Any(e => e.Id == id);
        }
    }
}
