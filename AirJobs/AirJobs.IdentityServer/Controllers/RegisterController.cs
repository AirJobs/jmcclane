using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using AirJobs.Domain.ValueObjects;
using AirJobs.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AirJobs.Domain.Entities.Users;

namespace AirJobs.IdentityServer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        [HttpGet("api/users")]
        public async Task<IActionResult> ListUsers()
        {
            var user = await unitOfWork.User.List();
            return Ok(user);
        }

        [HttpPost("api/register")]
        public async Task<IActionResult> Create([FromBody]UserCreateDto userVm)
        {
            if (!ModelState.IsValid)
                return BadRequest("ModelState is invalid");

            var newUser = await unitOfWork.User.Add(new User
            {
                Name = new Name(userVm.FirstName, userVm.LastName)
            });

            var appUser = new ApplicationUser
            {
                Email = userVm.Email,
                UserName = userVm.Email,
                UserId = newUser.Id
            };

            var identityResult = await userManager.CreateAsync(appUser, userVm.Password);

            if (!identityResult.Succeeded)
                return BadRequest(identityResult.Errors.Select(x => x.Description).ToList());

            var result = await unitOfWork.SaveAsync();
            if (!result)
                return NoContent();

            return Ok();
        }
    }
}
