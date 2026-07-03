using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Dto.Section
{
    public class CreateSectionDto
    {

        
        [Required]
        public string Name { get; set; }
        [Required]
        public int LibraryId { get; set; }
         
    }
}
