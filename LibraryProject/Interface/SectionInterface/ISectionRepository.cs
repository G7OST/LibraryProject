

using LibraryProject.Models;

namespace LibraryProject.Interface.SectionInterface
{
    public interface ISectionRepository
    {
        Task<Section> CreateSectionAsync(Section section);
        Task<List<Section>> GetAllSectionsAsync();
        Task<Section> GetSectionByIDAsync(int id);
        Task<bool> UpdateSectionAsync(Section section);
        Task<bool> DeleteSectionAsync(Section section);
    }
}
