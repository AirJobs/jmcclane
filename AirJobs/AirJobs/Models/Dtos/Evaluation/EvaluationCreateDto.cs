using System;

namespace AirJobs.Models.Dtos.Evaluation
{
    public class EvaluationCreateDto
    {
        public int Stars { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
