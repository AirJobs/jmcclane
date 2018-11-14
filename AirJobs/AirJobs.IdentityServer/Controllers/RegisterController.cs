using AirJobs.Domain.Entities.Users;
using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using AirJobs.Domain.ValueObjects;
using AirJobs.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Create(UserCreateDto userVm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Model invalid");

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
                    return BadRequest(identityResult.Errors);

                var result = await unitOfWork.SaveAsync();
                if (!result)
                    return BadRequest("User not save");

                return Ok("success");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
