using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Models;
using PhoneBook.Identity.Models;

namespace PhoneBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        // Post: api/User/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Email or Password not valid !!");
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            if (!(await _roleManager.RoleExistsAsync("User"))) 
                await _roleManager.CreateAsync(new IdentityRole("User"));

            var result = await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user,"User");
                return Ok("Your registration process has been completed successfully.");
            }            
            return BadRequest(result.Errors.Select(c=>c.Description));
            
        }

        // Post: api/User/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid !");
            }
          
            var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
            if (result.Succeeded)
            {
                return Ok("Login was successful.");
            }
            return BadRequest("User Name or Password is not valid !!");
        }

        // Post api/User/Logout
        [HttpPost("Logout")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("You are logout");
        }

    }
}
