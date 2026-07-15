using LibraryProject.Data;
using LibraryProject.Dto.Book;
using LibraryProject.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Repository
{
    public class BookRepository
    {
        public  BookRepository(AppDbContext db) { _db = db; }
        private readonly AppDbContext _db;
        public async Task<ResponseBookDto> CreateAsync(CreateBookDto createBookDto) {
            await _db.Book.AddAsync(createBookDto.Adapt<Book>());
            await _db.SaveChangesAsync();
            return createBookDto.Adapt<ResponseBookDto>();
        
        }
        public async Task<ResponseBookDto> GetBookByIdAsync(int id) { 
            var result=await _db.Book.FirstOrDefaultAsync(op=>op.BookID==id);
            if (result == null) { throw new KeyNotFoundException("Invalid Book_Id"); }
            return result.Adapt<ResponseBookDto>();
        
        }
        public async Task<List<ResponseBookDto>> GetBooksBySectionId(int id)
        {
            var books= await _db.Book.Where(op=>op.SectionId==id).ToListAsync();
            return books.Adapt<List<ResponseBookDto>>() ;
        }
        public async Task<bool> DeleteAsync(Book book) { 
             _db.Book.Remove(book);
            return true;
        }

    }
}
