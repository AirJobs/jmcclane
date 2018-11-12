using AirJobs.Domain.Entities.Addresses;
using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using AirJobs.IdentityServer;
using AirJobs.Models.Dtos.Address;
using AirJobs.Models.Dtos.Job;
using AirJobs.Models.Dtos.Scheduling;
using AirJobs.Models.Dtos.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AirJobs.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {

        #region Constructor / Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;


        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #endregion

        [HttpGet("{userId:guid}", Name = "GetUserById")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserItemDto))]
        public async Task<IActionResult> Get(Guid userId)
        {
            var user = await unitOfWork.User.Get(userId);

            if (user == null)
                return NotFound();

            var userVm = mapper.Map<UserItemDto>(user);
            return Ok(userVm);
        }

        [HttpGet("{userId:guid}/schedulings")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<SchedulingListDto>))]
        public async Task<IActionResult> ListBySchedulings(Guid userId)
        {
            var schedulings = await unitOfWork.Scheduling.ListByUser(userId);
            if (!schedulings.Any())
                return NotFound();

            var schedulingsVm = mapper.Map<IEnumerable<SchedulingListDto>>(schedulings);
            return Ok(schedulingsVm);
        }

        [HttpPost()]
        public async Task Create(string email, string password)
        {

        }

        [HttpGet("{userId:guid}/addresses")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<AddressListDto>))]
        public async Task<IActionResult> ListAddress(Guid userId)
        {
            var addresses = await unitOfWork.Address.ListByUser(userId);
            if (!addresses.Any())
                return NotFound();

            var addressesVm = mapper.Map<IEnumerable<AddressListDto>>(addresses);
            return Ok(addressesVm);
        }

        [HttpGet("{userId:guid}/addresses/{addressId:guid}", Name = "GetAddressById")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AddressItemDto))]
        public async Task<IActionResult> GetAddress(Guid userId, Guid addressId)
        {
            var address = await unitOfWork.Address.Get(addressId);
            if (address == null)
                return NotFound();

            var addressVm = mapper.Map<AddressItemDto>(address);
            return Ok(addressVm);
        }

        [HttpPost("{userId:guid}/addresses")]
        public async Task<IActionResult> CreateAddress(Guid userId, [FromBody]AddressCreateDto addressVm)
        {
            var address = mapper.Map<Address>(addressVm);
            address.UserId = userId;
            var newAddress = await unitOfWork.Address.Add(address);

            var result = await unitOfWork.SaveAsync();
            if (!result)
                return NoContent();

            return CreatedAtRoute("GetAddressById", new { userId = newAddress.UserId, addressId = newAddress.Id }, newAddress);
        }

        [HttpGet("{userId:guid}/favorites-jobs", Name = "ListFavoritesByUser")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<JobListDto>))]
        public async Task<IActionResult> ListFavorites(Guid userId)
        {
            var favoriteJobs = await unitOfWork.Job.ListFavoritesByUser(userId);
            if (!favoriteJobs.Any())
                return NotFound();

            var jobsVm = mapper.Map<IEnumerable<JobListDto>>(favoriteJobs);
            return Ok(jobsVm);
        }
    }
}
