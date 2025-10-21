using Hotel_Management_System.DBC;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Controllers
{
    public class GuestsController : Controller
    {
        private readonly HotelDBContext _db;

        public GuestsController(HotelDBContext db)
        {
            _db = db;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guests guests)
        {
            if (ModelState.IsValid)
            {
                await _db.Hotel.AddAsync(guests);
                await _db.SaveChangesAsync();
            }
            return View(guests);
        }

        public async Task<IActionResult> Get()
        {
            var get = await _db.Hotel.ToListAsync();
            return View(get);
        }
        public async Task<IActionResult> Details(int id)
        {
            var details = await _db.Hotel.FindAsync(id);
            if (details == null)
            {
                return NotFound();
            }
            return View(details);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guests guests)
        {
            if (ModelState.IsValid)
            {
                _db.Hotel.Update(guests);
                await _db.SaveChangesAsync();
                return RedirectToAction("Get");
            }
            return View(guests);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var del = await _db.Hotel.FindAsync(id);
            if (del == null)
            {
                return NotFound();
            }
            _db.Hotel.Remove(del);
            await _db.SaveChangesAsync();
            return RedirectToAction("Get");
        }
    }
}
