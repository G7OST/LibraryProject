using LibraryProject.Dto.Library;
using LibraryProject.Models;

namespace LibraryProject.Interface.LibraryInterface
{
    public interface ILibraryService
    {
        Task<LibraryDto> CreateLibraryAsync(LibraryDto library, string owenerId);
        Task<bool> DeleteAsync(int id);
        Task<LibraryDto> UpdateAsync(int id);
        Task<LibraryDto> GetByidAsync(int id);
        Task<List<LibraryDto>> GetAllAsync();

    }
}
