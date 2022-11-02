using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SarahASL.Models
{
    public class ASLTerm
    {
        public int Id { get; set; }

        [Required]
        public string? AslUserId { get; set; }
        public string? EnglishPhrase { get; set; }
        public byte[]? FileData { get; set; }
        public string? FileType { get; set; }
        [NotMapped]
        public IFormFile? VideoFile { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public virtual ASLUser? AslUser { get; set; }
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

    }
}
