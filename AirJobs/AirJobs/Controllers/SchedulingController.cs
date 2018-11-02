using AirJobs.Domain.Entities.Jobs;
using AirJobs.Domain.Entities.Users;
using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using AirJobs.Models.Dtos.Evaluation;
using AirJobs.Models.Dtos.Scheduling;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirJobs.Controllers
{
    [Route("api/schedulings")]
    public class SchedulingController : Controller
    {
        #region Constructor / Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SchedulingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #endregion
      
        [HttpGet("{id:guid}", Name = "GetSchedulingById")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SchedulingListDto>))]
        public async Task<IActionResult> GetScheduling(Guid id)
        {
            var scheduling = await unitOfWork.Scheduling.Get(id);
            if (scheduling == null)
                return NotFound();

            var schedulingVm = mapper.Map<IEnumerable<SchedulingListDto>>(scheduling);
            return Ok(schedulingVm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateScheduling([FromBody]SchedulingCreateDto vm)
        {
            var scheduling = mapper.Map<Scheduling>(vm);
            var newScheduling = await unitOfWork.Scheduling.Add(scheduling);
            var result = await unitOfWork.SaveAsync();

            if (!result)
                return NoContent();

            return CreatedAtRoute("GetSchedulingById", new {id = newScheduling.Id}, newScheduling);
        }

        [HttpPost("{id:guid}/evaluation")]
        public async Task<IActionResult> CreateEvalution(Guid id, [FromBody]EvaluationCreateDto vm)
        {
            var evaluation = mapper.Map<Evaluation>(vm);
            var scheduling = await unitOfWork.Scheduling.Get(id);
            evaluation.SchedulingId = scheduling.Id;
            evaluation.JobId = scheduling.JobId;

            var newEvaluation = await unitOfWork.Evaluation.Add(evaluation);
            var result = await unitOfWork.SaveAsync();

            if (!result)
                return NoContent();

            return CreatedAtRoute("GetSchedulingById", new { id = evaluation.Id }, newEvaluation);
        }
    }
}
