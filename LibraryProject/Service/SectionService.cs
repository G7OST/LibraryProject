using LibraryProject.Dto.Section;
using LibraryProject.Interface.LibraryInterface;
using LibraryProject.Interface.SectionInterface;
using LibraryProject.Models;
using LibraryProject.Repository;
using Mapster;
using Microsoft.AspNetCore.Diagnostics;

namespace LibraryProject.Service
{
    public class SectionService : ISectionService
    {
        public SectionService(ISectionRepository sectionRepo, ILibraryRepository libraryRepo) { _sectionRepo = sectionRepo;
            _libraryRepo = libraryRepo; }
        private readonly ISectionRepository _sectionRepo;
        private readonly ILibraryRepository _libraryRepo;

    
    public async Task<ResponseSectionDto> createSection(CreateSectionDto section) {
            var lib_id = section.LibraryId;
            var library = await _libraryRepo.GetByIdAsync(lib_id);
            if (library == null) {
                throw new KeyNotFoundException("Invalid Library Id");
            }
            var sec = new Section
            {
                Name = section.Name,
                LibraryId = lib_id,


            };
             await _sectionRepo.CreateSectionAsync(sec);
            return sec.Adapt<ResponseSectionDto>();

        }
        public async Task<ResponseSectionDto> GetSectionById(SectionDto sectionDto)
        {
           var result= await _sectionRepo.GetSectionByIDAsync(sectionDto.LibraryId);
            return result.Adapt<ResponseSectionDto>();
        }
        public async Task<List<ResponseSectionDto>>getAllSectionsByLibId(int Lib_id)
        {
            return await _sectionRepo.GetAllSectionsByLibIdAsync(Lib_id);
        }
        public async Task<bool> DeleteSectionAsync(int LibId,int SecId) {
            Section section=await _sectionRepo.GetSectionByIDAsync(SecId);
            if(section == null) { throw new KeyNotFoundException("Invalid section_Id"); }
            var result = false;
            if (section.LibraryId == LibId) { result = await _sectionRepo.DeleteSectionAsync(section); }
            if (result == false) { throw new KeyNotFoundException("Invalid Section"); }
            return true;
        }
        public async Task<bool>updateSection(int Sec_id,int lib_id,UpdateSectionDto sectionDto)
        {
            Section existSeciton = await _sectionRepo.GetSectionByIDAsync(Sec_id);
            if (existSeciton == null) { return false; }
            
            if (existSeciton.LibraryId !=lib_id)
            {
                return false;
            }
            existSeciton.Name = sectionDto.Name;
            var res=await _sectionRepo.UpdateSectionAsync(existSeciton);
            return true;


        }
    }
}
