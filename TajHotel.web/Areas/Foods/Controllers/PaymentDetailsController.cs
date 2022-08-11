using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TajHotel.Models;
using TajHotel.web.Data;

namespace TajHotel.web.Areas.Foods.Controllers
{
    [Area("Foods")]
    public class PaymentDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Foods/PaymentDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PaymentDetail.Include(p => p.Order).Include(p => p.foods);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Foods/PaymentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetail
                .Include(p => p.Order)
                .Include(p => p.foods)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return View(paymentDetail);
        }

        // GET: Foods/PaymentDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderName");
            ViewData["FoodId"] = new SelectList(_context.Foods, "FoodId", "FoodName");
            return View();
        }

        // POST: Foods/PaymentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,OrderId,FoodId")] PaymentDetail paymentDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderName", paymentDetail.OrderId);
            ViewData["FoodId"] = new SelectList(_context.Foods, "FoodId", "FoodName", paymentDetail.FoodId);
            return View(paymentDetail);
        }

        // GET: Foods/PaymentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetail.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderName", paymentDetail.OrderId);
            ViewData["FoodId"] = new SelectList(_context.Foods, "FoodId", "FoodName", paymentDetail.FoodId);
            return View(paymentDetail);
        }

        // POST: Foods/PaymentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,OrderId,FoodId")] PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentDetailExists(paymentDetail.PaymentId))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderName", paymentDetail.OrderId);
            ViewData["FoodId"] = new SelectList(_context.Foods, "FoodId", "FoodName", paymentDetail.FoodId);
            return View(paymentDetail);
        }

        // GET: Foods/PaymentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetail
                .Include(p => p.Order)
                .Include(p => p.foods)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return View(paymentDetail);
        }

        // POST: Foods/PaymentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentDetail = await _context.PaymentDetail.FindAsync(id);
            _context.PaymentDetail.Remove(paymentDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetail.Any(e => e.PaymentId == id);
        }
    }
}
