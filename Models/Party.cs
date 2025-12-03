using System.ComponentModel.DataAnnotations;

namespace PartyManager.Models
{
    public class Party
    {
        public int PartyId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(50, ErrorMessage = "Location cannot exceed 50 characters")]
        public string Location { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

        public List<Invitation> Invitations { get; set; } = new List<Invitation>();
    }
}