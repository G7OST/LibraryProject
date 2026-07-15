using LibraryProject.Dto.Library;
using LibraryProject.Interface.LibraryInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryProject.Controllers
{
    [Route("api/Library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        public LibraryController(ILibraryService libraryService) { _libraryService = libraryService; }
        private readonly ILibraryService _libraryService;
        [HttpPost("CreateLibrary")]
        public async Task<IActionResult> CreateLibrary(LibraryDto library)
        {
            var owner = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _libraryService.CreateLibraryAsync(library, owner);
            if (result == null)
            {
                return BadRequest("you already have a library");

            }
            return Ok(result);

        }
        [HttpGet("GetAllLibraries")]
        public async Task<List<LibraryDto>> GetAllLibrary()
        {
            return await _libraryService.GetAllAsync();
        }
        [HttpGet("GetLibraryByID")]
        public async Task<IActionResult> GetLibraryByID(int Id)
        {
            var result = await _libraryService.GetByidAsync(Id);
            if (result == null)
            {
                return BadRequest($"InvalidId:{Id}");
            }
            return Ok(result);
        }
        [HttpDelete("DeleteLibrary")]
        public async Task<IActionResult> DeleteLibrary(int Id) {
            var ownerid = User.FindFirstValue(ClaimTypes.NameIdentifier);
           var resualt= await _libraryService.DeleteAsync(Id);
            if (resualt == true)
            {
                return Ok("Library deleted succsesfully");
            }

            return BadRequest("invalid id");
        }
        [HttpPut("UpdateLibrary")]
        public async Task<IActionResult> UpdateLibrary(int id,LibraryDto libraryDto)
        {
            var resualt = await _libraryService.UpdateAsync(id,libraryDto);
            return Ok(resualt);
        }
        
    }
}
