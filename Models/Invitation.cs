using System.ComponentModel.DataAnnotations;

namespace PartyManager.Models
{
    public class Invitation
    {
        public int InvitationId { get; set; }

        [Required]
        public string GuestName { get; set; }

        [Required]
        [EmailAddress]
        public string GuestEmail { get; set; }

        public string Response { get; set; }

        [Required]       
        public int PartyId { get; set; }

        public Party Party { get; set; }   
    }
}