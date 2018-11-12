using AirJobs.Domain.Entities.Users;
using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using AirJobs.Domain.ValueObjects;
using AirJobs.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

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
        public async Task<HttpStatusCode> Create(UserCreateDto userVm)
        {
            if (!ModelState.IsValid)
                return HttpStatusCode.BadRequest;

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
                return HttpStatusCode.BadRequest;

            var result = await unitOfWork.SaveAsync();
            if (!result)
                return HttpStatusCode.NoContent;

            return HttpStatusCode.OK;
        }
    }
}
