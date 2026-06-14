using LibraryProject.Data;
using LibraryProject.Dto.Library;
using LibraryProject.Interface.LibraryInterface;
using LibraryProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        public LibraryRepository(AppDbContext db) { _db = db; }
        private readonly AppDbContext _db;

        public async Task<Library>CreateAsync(Library library)
        {
            await _db.Library.AddAsync(library);
            await _db.SaveChangesAsync();
            return library;
        }
        public async Task<List<Library>> GetAllLibraryAsync()
        {
            return await _db.Library.ToListAsync();
        }
        public async Task<Library?> GetByIdAsync(int id) {
            return await _db.Library.FirstOrDefaultAsync(op=>op.LibraryId==id);
            
        
        }
        public async Task<Library?>GetByOwnerIdAsync(string ownerid)
        {
            return await _db.Library.FirstOrDefaultAsync(op=>op.OwnerId==ownerid);
        }
        public async Task<bool> deleteLibraryAsync(string owenerid)
        {
           var lib=  await _db.Library.FirstOrDefaultAsync(Op=>Op.OwnerId==owenerid);
            if (lib == null) { return false; }
            else
            {
             
                _db.Library.Remove(lib);
                _db.SaveChanges();
                return true;
            }
            
        }
        public async Task UdpdateLibraryAsync(Library library) {
            _db.Library.Update(library);
             await _db.SaveChangesAsync();
            
            
        
        }
    }
}
