using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public Appuser Owner { get; set; }
        [Required]
        public TimeSpan OpeningTime { get; set; }
        [Required]
        public TimeSpan ClosingTime { get; set; }
        public ICollection<Section> section { get; set; } = new List<Section>();



    }
}
