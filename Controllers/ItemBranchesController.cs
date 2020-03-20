using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class ItemBranchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemBranchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemBranches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ItemesBranches.Include(i => i.branches).Include(i => i.items);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ItemBranches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemBranch = await _context.ItemesBranches
                .Include(i => i.branches)
                .Include(i => i.items)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemBranch == null)
            {
                return NotFound();
            }

            return View(itemBranch);
        }

        // GET: ItemBranches/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId");
            ViewData["BranchId"] = new SelectList(_context.Items, "ItemId", "ItemId");
            return View();
        }

        // POST: ItemBranches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,BranchId")] ItemBranch itemBranch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemBranch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId", itemBranch.BranchId);
            ViewData["BranchId"] = new SelectList(_context.Items, "ItemId", "ItemId", itemBranch.BranchId);
            return View(itemBranch);
        }

        // GET: ItemBranches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemBranch = await _context.ItemesBranches.FindAsync(id);
            if (itemBranch == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId", itemBranch.BranchId);
            ViewData["BranchId"] = new SelectList(_context.Items, "ItemId", "ItemId", itemBranch.BranchId);
            return View(itemBranch);
        }

        // POST: ItemBranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,BranchId")] ItemBranch itemBranch)
        {
            if (id != itemBranch.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemBranch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemBranchExists(itemBranch.ItemId))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId", itemBranch.BranchId);
            ViewData["BranchId"] = new SelectList(_context.Items, "ItemId", "ItemId", itemBranch.BranchId);
            return View(itemBranch);
        }

        // GET: ItemBranches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemBranch = await _context.ItemesBranches
                .Include(i => i.branches)
                .Include(i => i.items)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemBranch == null)
            {
                return NotFound();
            }

            return View(itemBranch);
        }

        // POST: ItemBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemBranch = await _context.ItemesBranches.FindAsync(id);
            _context.ItemesBranches.Remove(itemBranch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemBranchExists(int id)
        {
            return _context.ItemesBranches.Any(e => e.ItemId == id);
        }
    }
}
