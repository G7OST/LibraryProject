using LibraryProject.Interface.SectionInterface;
using LibraryProject.Repository;

namespace LibraryProject.Service
{
    public class SectionService : ISectionService
    {
        public SectionService(ISectionRepository sectionRepo) { _sectionRepo = sectionRepo; }
        private readonly ISectionRepository _sectionRepo;

    }
}
