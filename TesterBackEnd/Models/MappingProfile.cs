using AutoMapper;
using TesterBackEnd.Models;
using TesterBackEnd.Models.DTOs;

namespace TesterBackEnd
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map from ProjectDTO to Project
            CreateMap<ProjectDTO, Project>()
     .ForMember(dest => dest.Transformers, opt => opt.Ignore());

            // Map from Project to ProjectDTO
            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.Transformers, opt => opt.MapFrom(src => src.Transformers));

            // Map from TransformerDTO to Transformer
            CreateMap<TransformerDTO, Transformer>();

            // Map from Transformer to TransformerDTO
            CreateMap<Transformer, TransformerDTO>();

            //Map from ActiveTestReportDTO to ActiveTestReport
            CreateMap<ActiveTestReportDTO, ActiveTestReport>();

            //Map from ActiveTestReport to ActiveTestReportDTO
            CreateMap<ActiveTestReport, ActiveTestReportDTO>();

            //map from HvResistanceDTO to HvResistance
            CreateMap<HvResistanceDTO, HvResistance>();

            //map from HvResistance to HvResistanceDTO
            CreateMap<HvResistance, HvResistanceDTO>();

        }
    }
}
