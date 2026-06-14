using LibraryProject.Models;

namespace LibraryProject.Interface.TokenInterface
{
    public interface IToken
    {
        Task<string> CreateTokenAsync(Appuser appuser);
    }
}
