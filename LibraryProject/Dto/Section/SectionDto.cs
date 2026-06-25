using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Dto.Section
{
    public class SectionDto
    {

        [Key]
        public int SectionId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
