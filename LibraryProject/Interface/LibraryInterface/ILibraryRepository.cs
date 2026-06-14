using LibraryProject.Models;

namespace LibraryProject.Interface.LibraryInterface
{
    public interface ILibraryRepository
    {
        Task<Library> CreateAsync(Library library);
        Task<Library?> GetByOwnerIdAsync(string ownerid);
        Task<bool> deleteLibraryAsync(string owenerid);
            Task UdpdateLibraryAsync(Library library);
            Task<List<Library>> GetAllLibraryAsync();
            Task<Library?> GetByIdAsync(int id);

    }
}
