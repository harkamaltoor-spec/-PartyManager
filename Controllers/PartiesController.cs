using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyManager.Data;
using PartyManager.Models;

namespace PartyManager.Controllers
{
    public class PartiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ⭐ Anyone can view parties
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var parties = await _context.Parties
                //   .Where(p => !p.IsDeleted) Changed
                .ToListAsync();

            return View(parties);
        }

        // ⭐ Anyone can view details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            // ⭐ FIXED: Include Invitations to avoid null reference
            var party = await _context.Parties
                .Include(p => p.Invitations)
               // .FirstOrDefaultAsync(p => p.PartyId == id && !p.IsDeleted); Chnanged

                .FirstOrDefaultAsync(p => p.PartyId == id);

            if (party == null) return NotFound();

            return View(party);
        }

        // ⭐ Only logged in users can create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // ⭐ Only logged in users can create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Party party)
        {
            if (!ModelState.IsValid)
                return View(party);

            _context.Add(party);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ⭐ Only logged in users can edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var party = await _context.Parties.FindAsync(id);
            if (party == null) return NotFound();

            return View(party);
        }

        // ⭐ Only logged in users can edit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Party party)
        {
            if (id != party.PartyId) return NotFound();

            if (!ModelState.IsValid)
                return View(party);

            _context.Update(party);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ⭐ Only Admin can delete
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var party = await _context.Parties
                .FirstOrDefaultAsync(p => p.PartyId == id);

            if (party == null) return NotFound();

            return View(party);
        }

        // ⭐ Only Admin can delete (soft delete)
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var party = await _context.Parties.FindAsync(id);
            if (party == null) return NotFound();

            party.IsDeleted = true;   // Soft delete
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ⭐ Only Admin can undo delete
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Undo(int id)
        {
            var party = await _context.Parties.FindAsync(id);
            if (party == null) return NotFound();

            party.IsDeleted = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
