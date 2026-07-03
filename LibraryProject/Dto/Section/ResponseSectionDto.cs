using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Dto.Section
{
    public class ResponseSectionDto
    {
        
        public int SectionId { get; set; }
        
        public string Name { get; set; }
        public int LibraryId { get; set; }


    }
}
