using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PartyManager.Data;
using PartyManager.Models;

namespace PartyManager.Controllers
{
    [Authorize]
    public class InvitationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvitationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Invitations/Create?partyId=#
        public IActionResult Create(int partyId)
        {
            if (partyId == 0)
                return BadRequest("Missing partyId");

            var invitation = new Invitation
            {
                PartyId = partyId
            };

            return View(invitation);
        }

        // POST: Invitations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Invitation invitation)
        {
            Console.WriteLine("=== POST /Invitations/Create HIT ===");
            Console.WriteLine("PartyId = " + invitation.PartyId);
            Console.WriteLine("GuestName = " + invitation.GuestName);
            Console.WriteLine("GuestEmail = " + invitation.GuestEmail);
            Console.WriteLine("Response = " + invitation.Response);

            if (!ModelState.IsValid)
            {
                Console.WriteLine("MODEL STATE INVALID");
                return View(invitation);
            }

            if (invitation.PartyId == 0)
            {
                Console.WriteLine("ERROR: PartyId is ZERO");
                return BadRequest("PartyId missing.");
            }

            if (string.IsNullOrEmpty(invitation.Response))
            {
                Console.WriteLine("Response empty → setting to Pending");
                invitation.Response = "Pending";
            }

            try
            {
                Console.WriteLine("Adding invitation...");
                _context.Invitations.Add(invitation);

                Console.WriteLine("Saving to database...");
                await _context.SaveChangesAsync();

                Console.WriteLine("SUCCESS: Invitation saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB ERROR: " + ex.Message);
                return Content(ex.Message);
            }

            return RedirectToAction("Details", "Parties", new { id = invitation.PartyId });
        }
    }
}
