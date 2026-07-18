using LibraryProject.Data;
using LibraryProject.Dto.Book;
using LibraryProject.Interface.BookInterface;
using LibraryProject.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Repository
{
    public class BookRepository : IBookRepository
    {
        public  BookRepository(AppDbContext db) { _db = db; }
        private readonly AppDbContext _db;
        public async Task<ResponseBookDto> CreateAsync(Book book) {
            await _db.Book.AddAsync(book);
            await _db.SaveChangesAsync();
            return book.Adapt<ResponseBookDto>();
        
        }
        public async Task<ResponseBookDto> GetBookByIdAsync(int id) { 
            var result=await _db.Book.FirstOrDefaultAsync(op=>op.BookID==id);
            if (result == null) { throw new KeyNotFoundException("Invalid Book_Id"); }
            return result.Adapt<ResponseBookDto>();
        
        }
        public async Task<List<ResponseBookDto>> GetBooksBySectionIdAsync(int id)
        {
            var books= await _db.Book.Where(op=>op.SectionId==id).ToListAsync();
            return books.Adapt<List<ResponseBookDto>>() ;
        }
        public async Task<bool> DeleteAsync(int id) {
            var result=await _db.Book.FirstOrDefaultAsync(o => o.BookID == id);
             _db.Book.Remove(result);
            return true;
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
           return await _db.Book.ToListAsync();
           
        }

    }
}
