using AirJobs.Domain.Entities.Jobs;
using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using AirJobs.Models.Dtos.Job;
using AirJobs.Models.Filters;
using AirJobs.Models.Request;
using AutoMapper;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AirJobs.Controllers
{
    [Route("api/jobs")]
    public class JobController : Controller
    {
        #region Constructor / Fields

        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public JobController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #endregion

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ListResponse<JobListDto>))]
        public IActionResult List([FromQuery]ListJobsFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest("ModelState is invalid");

            var geo = new GeoCoordinate(filter.Latitude, filter.Longitude);
            var jobs = unitOfWork.Job.SearchAndPaginate(filter.CityName, geo, filter.Page, filter.Size, out var total);

            var result = new ListResponse<JobListDto>
            {
                Total = total,
                Data = mapper.Map<IEnumerable<JobListDto>>(jobs)
            };

            return Ok(result);
        }

        [HttpGet("{id:guid}", Name = "GetJobById")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(JobItemDto))]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var job = await unitOfWork.Job.Get(id);
                if (job == null)
                    return NotFound();

                var jobItem = mapper.Map<JobItemDto>(job);
                return Ok(jobItem);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Created([FromBody]JobCreateDto createdVM)
        {
            if (!ModelState.IsValid)
                return BadRequest("ModelState is invalid");

            var job = mapper.Map<Job>(createdVM);
            var newJob = await unitOfWork.Job.Add(job);
            var result = await unitOfWork.SaveAsync();

            if (!result)
                return NoContent();

            return CreatedAtRoute("GetJobById", new {id = newJob.Id}, newJob);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await unitOfWork.Job.Remove(id);
            var result = await unitOfWork.SaveAsync();
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpPost("{jobId:guid}/favorite")]
        public async Task<IActionResult> CreateFavorite(Guid jobId, [FromQuery]Guid userId)
        {
            var favorite = await unitOfWork.Favorite.Add(new Favorite
            {
                JobId = jobId,
                UserId = userId
            });

            var result = await unitOfWork.SaveAsync();
            if (!result)
                return BadRequest("Not implemented");

            var job = mapper.Map<JobItemDto>(unitOfWork.Job.Get(jobId));

            return CreatedAtRoute("ListFavoritesByUser", new {userId = userId}, job);
        }
    }
}
