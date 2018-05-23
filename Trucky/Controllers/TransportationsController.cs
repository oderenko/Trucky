using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trucky.Models.DB;

namespace Trucky.Controllers {
  public class TransportationsController : Controller
    {
        private readonly TruckyContext _context;

        public TransportationsController(TruckyContext context)
        {
            _context = context;
        }

        // GET: Transportations
        public async Task<IActionResult> Index()
        {
            var truckyContext = _context.Transportations.Include(t => t.TruckF);
            return View(await truckyContext.ToListAsync());
        }

        // GET: Transportations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.Transportations
                .Include(t => t.TruckF)
                .SingleOrDefaultAsync(m => m.TransportationId == id);
            if (transportation == null)
            {
                return NotFound();
            }

            return View(transportation);
        }

        // GET: Transportations/Create
        public IActionResult Create()
        {
            ViewData["TruckFid"] = new SelectList(_context.Trucks, "TruckId", "TruckId");
            return View();
        }

        // POST: Transportations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransportationId,DeliveryDate,StartDate,TruckFid")] Transportation transportation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TruckFid"] = new SelectList(_context.Trucks, "TruckId", "TruckId", transportation.TruckFid);
            return View(transportation);
        }

        // GET: Transportations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.Transportations.SingleOrDefaultAsync(m => m.TransportationId == id);
            if (transportation == null)
            {
                return NotFound();
            }
            ViewData["TruckFid"] = new SelectList(_context.Trucks, "TruckId", "TruckId", transportation.TruckFid);
            return View(transportation);
        }

        // POST: Transportations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransportationId,DeliveryDate,StartDate,TruckFid")] Transportation transportation)
        {
            if (id != transportation.TransportationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationExists(transportation.TransportationId))
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
            ViewData["TruckFid"] = new SelectList(_context.Trucks, "TruckId", "TruckId", transportation.TruckFid);
            return View(transportation);
        }

        // GET: Transportations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.Transportations
                .Include(t => t.TruckF)
                .SingleOrDefaultAsync(m => m.TransportationId == id);
            if (transportation == null)
            {
                return NotFound();
            }

            return View(transportation);
        }

        // POST: Transportations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transportation = await _context.Transportations.SingleOrDefaultAsync(m => m.TransportationId == id);
            _context.Transportations.Remove(transportation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportationExists(int id)
        {
            return _context.Transportations.Any(e => e.TransportationId == id);
        }
    }
}
