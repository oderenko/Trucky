using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trucky.Models.DB;

namespace Trucky.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly TruckyContext _context;

        public InvoicesController(TruckyContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var truckyContext = _context.Invoices.Include(i => i.Buyer).Include(i => i.Employee).Include(i => i.Goods).Include(i => i.Seller);
            return View(await truckyContext.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Buyer)
                .Include(i => i.Employee)
                .Include(i => i.Goods)
                .Include(i => i.Seller)
                .SingleOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["BuyerFid"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["EmployeeFid"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["GoodsFid"] = new SelectList(_context.Goods, "GoodsId", "GoodsId");
            ViewData["SellerFid"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceId,DateOfPay,GoodsFid,EmployeeFid,BuyerFid,SellerFid")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerFid"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", invoice.BuyerFid);
            ViewData["EmployeeFid"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", invoice.EmployeeFid);
            ViewData["GoodsFid"] = new SelectList(_context.Goods, "GoodsId", "GoodsId", invoice.GoodsFid);
            ViewData["SellerFid"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", invoice.SellerFid);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.SingleOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["BuyerFid"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", invoice.BuyerFid);
            ViewData["EmployeeFid"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", invoice.EmployeeFid);
            ViewData["GoodsFid"] = new SelectList(_context.Goods, "GoodsId", "GoodsId", invoice.GoodsFid);
            ViewData["SellerFid"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", invoice.SellerFid);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceId,DateOfPay,GoodsFid,EmployeeFid,BuyerFid,SellerFid")] Invoice invoice)
        {
            if (id != invoice.InvoiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.InvoiceId))
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
            ViewData["BuyerFid"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", invoice.BuyerFid);
            ViewData["EmployeeFid"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", invoice.EmployeeFid);
            ViewData["GoodsFid"] = new SelectList(_context.Goods, "GoodsId", "GoodsId", invoice.GoodsFid);
            ViewData["SellerFid"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", invoice.SellerFid);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Buyer)
                .Include(i => i.Employee)
                .Include(i => i.Goods)
                .Include(i => i.Seller)
                .SingleOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoices.SingleOrDefaultAsync(m => m.InvoiceId == id);
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.InvoiceId == id);
        }
    }
}
