using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnologies;
using Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnologies;
using Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnologies;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Profiles
{
    public class ProgrammingLanguageTechnologiesMapping:Profile
    {
        public ProgrammingLanguageTechnologiesMapping()
        {
            //Command
            CreateMap<ProgrammingLanguageTechnology, CreatedProgrammingLanguageTechnologiesDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologiesCommand>().ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, UpdatedProgrammingLanguageTechnologiesDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, UpdateProgrammingLanguageTechnologiesCommand>().ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, DeletedProgrammingLanguageTechnologiesDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, DeleteProgrammingLanguageTechnologiesCommand>().ReverseMap();

            //Query
            CreateMap<IPaginate<ProgrammingLanguageTechnology>, ProgrammingLanguageTechnologiesListModel>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, GetListProgrammingLanguageTechnologiesDto>().ForMember(c=>c.ProgrammingLanguageName,opt=>opt.MapFrom(c=>c.ProgrammingLanguage.Name)).ReverseMap();
        }
    }
}
