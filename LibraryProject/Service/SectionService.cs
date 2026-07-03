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
    }
}
