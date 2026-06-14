using LibraryProject.Dto.Library;
using LibraryProject.Interface.LibraryInterface;
using LibraryProject.Models;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.InteropServices;

namespace LibraryProject.Service
{
    public class LibraryService : ILibraryService
    {
        public LibraryService(ILibraryRepository librepo) { _librepo = librepo; }
        private readonly ILibraryRepository _librepo;

        public async Task<LibraryDto> CreateLibraryAsync(LibraryDto library, string owenerId)
        {
            var existlib= await _librepo.GetByOwnerIdAsync(owenerId);
            if (existlib != null)
            {
                return null;
            }
            
                var lib = new Library()
                {
                    Name = library.Name,
                    Address = library.Address,
                    PhoneNumber = library.PhoneNumber,
                    ClosingTime = library.ClosingTime,
                    OpeningTime = library.OpeningTime,
                    OwnerId = owenerId,
                    Description = library.Description,

                };
            
            
            
            var result=await _librepo.CreateAsync(lib);
            return result.Adapt<LibraryDto>();
            
        }
        public async Task<List<LibraryDto>>GetAllAsync()
        {
            var Libraries= await _librepo.GetAllLibraryAsync();
            var result = Libraries.Adapt<List<LibraryDto>>();
            return result;
        }
        public async Task<LibraryDto> GetByidAsync(int id)
        {
            var existuser = await _librepo.GetByIdAsync(id);
            if (existuser == null)
            {
                return null;
            }
            return existuser.Adapt < LibraryDto>();

        }
        public async Task<LibraryDto> UpdateAsync(Library library)
        {
            var updatedlib = new Library
            {
                Name= library.Name,
                Address= library.Address,
                PhoneNumber= library.PhoneNumber,
                ClosingTime= library.ClosingTime,
                OpeningTime= library.OpeningTime,
                OwnerId= library.OwnerId,
                Description = library.Description,

            };
           await _librepo.UdpdateLibraryAsync(updatedlib);
            return updatedlib.Adapt<LibraryDto>();
        }
        public async Task<bool> DeleteAsync(int id) { 
            var lib= await _librepo.GetByIdAsync(id);
            if (lib == null) { 
                return false;
            }
            await _librepo.deleteLibraryAsync(lib.OwnerId);
            return true;
        }

    }
}
