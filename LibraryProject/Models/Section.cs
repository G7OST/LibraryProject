using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        [Required]
        public string Name { get; set; }

        
        public ICollection<Book> books { get; set; } = new List<Book>();
        
        public int LibraryId { get; set; }
        [ForeignKey("LibraryId")]
        public Library library { get; set; }
    }
}
