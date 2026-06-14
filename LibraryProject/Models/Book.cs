using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public int Quaintity { get; set; }
        public int SectionId { get; set; }
        [ForeignKey("SectionId")]
        public Section section { get; set; }
    }
}
