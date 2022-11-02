using System.ComponentModel.DataAnnotations;

namespace SarahASL.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string? AslUserId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 2)]
        public string? Name { get; set; }
        public virtual ASLUser? AslUser { get; set; }

        public virtual ICollection<ASLTerm> ASLTerms { get; set; } = new HashSet<ASLTerm>();
    }
}
