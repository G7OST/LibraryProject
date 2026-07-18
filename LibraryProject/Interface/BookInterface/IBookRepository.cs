using LibraryProject.Dto.Book;
using LibraryProject.Models;

namespace LibraryProject.Interface.BookInterface
{
    public interface IBookRepository
    {
        Task<ResponseBookDto> CreateAsync(Book book);
        Task<ResponseBookDto> GetBookByIdAsync(int id);
        Task<List<ResponseBookDto>> GetBooksBySectionIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<List<Book>> GetAllBooksAsync();
    }
}
