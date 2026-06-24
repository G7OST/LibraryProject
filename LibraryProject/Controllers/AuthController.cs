using LibraryProject.Dto.User;
using LibraryProject.Interface.TokenInterface;
using LibraryProject.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(UserManager<Appuser> userManager,IToken token)
        {
            _userManager = userManager; _token = token;
        }
        private readonly UserManager<Appuser> _userManager;
        private readonly IToken _token;
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(Register user)
        {
            if (ModelState.IsValid)
            {
                if(!string.Equals(user.Role, "User", StringComparison.OrdinalIgnoreCase)&&
                    !string.Equals(user.Role, "LibraryOwner", StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest("Invalid Role");
                }
                Appuser existuser = await _userManager.FindByEmailAsync(user.Email);
                if (existuser != null) { return BadRequest("you alredy haver an account"); }
                var appuser = new Appuser
                {
                    UserName = user.Username,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    
                };
                
                var created = await _userManager.CreateAsync(appuser, user.Password);
                if (created.Succeeded)
                {
                    var role = user.Role.Equals("LibraryOwner", StringComparison.OrdinalIgnoreCase) ? "LibraryOwner" : "User";
                    var addrole = await _userManager.AddToRoleAsync(appuser, role);
                    return Ok(await _token.CreateTokenAsync(appuser));
                }
                if (!created.Succeeded)
                {
                    foreach (var error in created.Errors)
                        ModelState.AddModelError("", error.Description);
                }



            }
            return BadRequest("Register Failed");
        }
        [HttpPost("login")]
        public async Task<IActionResult> login_User(Login user)
        {
            if (ModelState.IsValid)
            {
                var existuser=await _userManager.FindByEmailAsync(user.Email); if (existuser == null) 
                { return BadRequest($"There is no user named{user} create new account"); }   

                if (await _userManager.CheckPasswordAsync(existuser, user.Password))
                {
                    return Ok(await _token.CreateTokenAsync(existuser));
                }
                else {
                    return Unauthorized();
                }
                
            }
            return BadRequest();
        }
    }
    
}
    
