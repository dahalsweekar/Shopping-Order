#nullable disable
using Make_Orders.Data;
using Make_Orders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Make_Orders.Controllers
{
    public class IteController : Controller
    {
        private readonly Make_OrdersContext _context;

        public IteController(Make_OrdersContext context)
        {
            _context = context;
        }

        // GET: Ite
        public async Task<IActionResult> Index()
        {
            var make_OrdersContext = _context.Items.Include(i => i.order);
            return View(await make_OrdersContext.ToListAsync());
        }

        // GET: Ite/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .Include(i => i.order)
                .FirstOrDefaultAsync(m => m.ItemsID == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Ite/Create
        public IActionResult Create()
        {
            ViewData["OrdersID"] = new SelectList(_context.Orders, "OrdersID", "OrdersID");
            return View();
        }

        // POST: Ite/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemsID,ItemsName,Item_type,Rate,OrdersID")] Items items)
        {
            if (ModelState.IsValid)
            {
                _context.Add(items);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrdersID"] = new SelectList(_context.Orders, "OrdersID", "OrdersID", items.OrdersID);
            return View(items);
        }

        // GET: Ite/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }
            ViewData["OrdersID"] = new SelectList(_context.Orders, "OrdersID", "OrdersID", items.OrdersID);
            return View(items);
        }

        // POST: Ite/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemsID,ItemsName,Item_type,Rate,OrdersID")] Items items)
        {
            if (id != items.ItemsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(items);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsExists(items.ItemsID))
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
            ViewData["OrdersID"] = new SelectList(_context.Orders, "OrdersID", "OrdersID", items.OrdersID);
            return View(items);
        }

        // GET: Ite/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .Include(i => i.order)
                .FirstOrDefaultAsync(m => m.ItemsID == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // POST: Ite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var items = await _context.Items.FindAsync(id);
            _context.Items.Remove(items);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.ItemsID == id);
        }
    }
}
