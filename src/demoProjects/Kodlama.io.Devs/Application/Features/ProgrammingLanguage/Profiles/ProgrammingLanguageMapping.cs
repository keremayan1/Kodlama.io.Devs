using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Models;
using AutoMapper;
using Core.Persistance.Paging;

namespace Application.Features.ProgrammingLanguage.Profiles
{
    public class ProgrammingLanguageMapping:Profile
    {
        public ProgrammingLanguageMapping()
        {
            CreateMap<Domain.Entities.ProgrammingLanguage, CreateProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<IPaginate<Domain.Entities.ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, GetByProgrammingLanguageIdDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, UpdateProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, DeleteProgrammingLanguageDto>().ReverseMap();
        }
    }
}
