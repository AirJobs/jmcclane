using AirJobs.Domain.Entities.Jobs;
using AirJobs.Domain.Entities.Jobs.Enumns;
using AirJobs.Models.Dtos.Evaluation;
using AutoMapper;

namespace AirJobs.AutoMapper
{
    public class EvaluationProfile : Profile
    {
        public EvaluationProfile()
        {
            CreateMap<EvaluationCreateDto, Evaluation>()
                .ForMember(evaluation => evaluation.Stars, config => config.MapFrom(dto => (EvaluationStarEnum) dto.Stars));

            CreateMap<Evaluation, EvaluationListForJobDto>()
                .ForMember(x => x.Stars, config => config.MapFrom(x => (int)x.Stars))
                .ForMember(x => x.UserName, config => config.MapFrom(x => x.User.Name.ToString()));
        }
    }
}
