using LibraryProject.Dto.Library;
using LibraryProject.Interface.LibraryInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/Library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        public LibraryController(ILibraryService libraryService) { _libraryService = libraryService; }
        private readonly ILibraryService _libraryService;
        [HttpPost("CreateLibrary")]
        public async Task<LibraryDto> CreateLibrary(LibraryDto library)
        {
            var result = await _libraryService.CreateLibraryAsync(library);
        }

    }
}
