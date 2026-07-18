using LibraryProject.Dto.Book;
using LibraryProject.Interface.BookInterface;
using LibraryProject.Models;
using LibraryProject.Repository;
using Mapster;

namespace LibraryProject.Service
{
    public class BookService
    {
        public BookService(IBookRepository bookRepo) { _bookRepo = bookRepo; }
        private readonly IBookRepository _bookRepo;
        public async Task<ResponseBookDto> CreateBookAsync(CreateBookDto createBookDto) {
            var book = new Book
            {
                Name=createBookDto.Name,
                Quaintity=createBookDto.Quaintity,
                SectionId=createBookDto.SectionId,
            };
            var result = await _bookRepo.CreateAsync(book);
            if(result == null)
            {
                throw new Exception("Failed to create book");
            }
            return result;
        }
        public async Task<List<ResponseBookDto>> GetAllBooksAsync()
        {
            var result = await _bookRepo.GetAllBooksAsync();
            return result.Adapt<List<ResponseBookDto>>();
        }
        public async Task<List<ResponseBookDto>> getBySecIDAsync(int id)
        {
            return await _bookRepo.GetBooksBySectionIdAsync(id);
        }
        public async Task<ResponseBookDto>GetBookByIdAsync(int id)
        {
            return await _bookRepo.GetBookByIdAsync(id);
        }
        public async Task<bool> DeleteBookAsync(int id,int secId)
        {
            var existbook=await _bookRepo.GetBookByIdAsync(id);
            if (existbook == null)
            {
                throw new KeyNotFoundException("invalid BookID");
            }
            if(existbook.SectionId !=secId)
            {
                throw new KeyNotFoundException("secId  not equal the one u send ");
            }
            var result = false; 
                result=await _bookRepo.DeleteAsync(id);
            if (result == false)
            {
                return false;

            }
            return true;
        }
    }
}
