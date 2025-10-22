using Hotel_Management_System.DBC;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Hotel_Management_System.Controllers
{
    [Authorize]
    public class GuestsController : Controller
    {

        private readonly HotelDBContext _db;

        public GuestsController(HotelDBContext db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber")] Guests guests)
        {
            if (ModelState.IsValid)
            {
                _db.Add(guests);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Get));
            }
            return View(guests);
        }

        public async Task<IActionResult> Get()
        {
            return View ( await _db.Hotel.ToListAsync());            
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var details = await _db.Hotel.FindAsync(id);
            if (details == null)
            {
                return NotFound();
            }
            return View(details);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var guest = await _db.Hotel.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var guest = await _db.Hotel.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guest = await _db.Hotel.FindAsync(id);
            if (guest == null) return NotFound();

            _db.Hotel.Remove(guest);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }

}
