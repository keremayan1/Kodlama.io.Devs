using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistance.Paging;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class ProgrammingLanguageMapping : Profile
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

