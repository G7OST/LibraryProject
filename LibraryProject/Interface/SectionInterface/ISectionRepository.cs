namespace LibraryProject.Interface.SectionInterface
{
    public class ISectionRepository
    {
        Task<Section> CreateSection(Section section);
        Task<List<Section>> GetAllSectionsAsync();
        Task<Section> GetSectionByID(int id);
        Task<bool> UpdateSectionAsync(Section section);
        Task<bool> DeleteSection(Section section);
    }
}
