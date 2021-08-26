using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITexusTaskOne.Data;
using ITexusTaskOne.Models;
using Microsoft.AspNetCore.Authorization;

namespace ITexusTaskOne.Controllers
{
    public class WagonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WagonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wagons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wagon.ToListAsync());
        }

        // GET: Wagons/SearchWagon
        public async Task<IActionResult> SearchWagon()
        {
            return View();
        }

        // POST: Wagons/ShowSearchWagon
        public async Task<IActionResult> ShowSearchWagon(string SInventoryNum, string SModel)
        {
            return View("Index", await _context.Wagon
                .Where(x => x.InventoryNum.Contains(SInventoryNum == null ? "" : SInventoryNum))
                .Where(x => x.Model.Contains(SModel == null ? "" : SModel))
                .ToListAsync());
        }


        // GET: Wagons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wagon = await _context.Wagon
                .FirstOrDefaultAsync(m => m.WagonID == id);
            if (wagon == null)
            {
                return NotFound();
            }

            return View(wagon);
        }

        // GET: Wagons/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wagons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WagonID,InventoryNum,Model,ProdDate,ExpDate,WagWeight")] Wagon wagon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wagon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wagon);
        }

        // GET: Wagons/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wagon = await _context.Wagon.FindAsync(id);
            if (wagon == null)
            {
                return NotFound();
            }
            return View(wagon);
        }

        // POST: Wagons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WagonID,InventoryNum,Model,ProdDate,ExpDate,WagWeight")] Wagon wagon)
        {
            if (id != wagon.WagonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wagon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WagonExists(wagon.WagonID))
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
            return View(wagon);
        }

        // GET: Wagons/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wagon = await _context.Wagon
                .FirstOrDefaultAsync(m => m.WagonID == id);
            if (wagon == null)
            {
                return NotFound();
            }

            return View(wagon);
        }

        // POST: Wagons/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wagon = await _context.Wagon.FindAsync(id);
            _context.Wagon.Remove(wagon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WagonExists(int id)
        {
            return _context.Wagon.Any(e => e.WagonID == id);
        }
    }
}
