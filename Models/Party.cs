using System.ComponentModel.DataAnnotations;

namespace PartyManager.Models
{
    public class Party
    {
        public int PartyId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required]
        public string Location { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<Invitation> Invitations { get; set; } = new List<Invitation>();
    }
}