using LibraryProject.Data;
using LibraryProject.Dto.Section;
using LibraryProject.Interface.SectionInterface;
using LibraryProject.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Repository
{
    public class SectionRepository :ISectionRepository
    {
        public SectionRepository(AppDbContext db) { _db = db; }
        private readonly AppDbContext _db;
        public async Task<Section> CreateSectionAsync(Section section)
        {
            await _db.Section.AddAsync(section);
            await _db.SaveChangesAsync();
            return section;
        }
        public async Task<List<Section>> GetAllSectionsAsync() 
        {
           
            return await _db.Section.ToListAsync();
        }
        public async Task<Section> GetSectionByIDAsync(int id)
        {
           return  await _db.Section.FirstOrDefaultAsync(op=>op.SectionId==id);
             
        }
        public async Task<bool> UpdateSectionAsync(Section section)
        {
            var update=  _db.Section.Update(section);
            await _db.SaveChangesAsync();
            return true;
                
                }
        public async Task<bool> DeleteSectionAsync(Section section)  {
            _db.Section.Remove(section);
            await _db.SaveChangesAsync();
            return true;
        }


    }
}
