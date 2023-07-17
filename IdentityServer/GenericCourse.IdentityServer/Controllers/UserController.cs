using GenericCourse.IdentityServer.DTOs;
using GenericCourse.IdentityServer.Models;
using GenericCourse.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace GenericCourse.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupDTO signupDTO)
        {
            var user = new ApplicationUser
            {
                UserName = signupDTO.UserName,
                Email = signupDTO.Email
            };

            var result = await _userManager.CreateAsync(user, signupDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user == null)
                return BadRequest();

            return Ok(new {Id = user.Id, UserName = user.UserName, Email = user.Email});
        }
    }
}
