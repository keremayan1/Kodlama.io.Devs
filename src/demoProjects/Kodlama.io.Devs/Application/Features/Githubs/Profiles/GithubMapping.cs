using Application.Features.Githubs.Commands.CreateGithub;
using Application.Features.Githubs.Commands.DeleteGithub;
using Application.Features.Githubs.Commands.UpdateGithub;
using Application.Features.Githubs.Dtos;
using Application.Features.Githubs.Models;
using Application.Features.Githubs.Queries.GetByGithubId;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Profiles
{
    public class GithubMapping:Profile
    {
        public GithubMapping()
        {
            //Create
            CreateMap<Github, CreatedGithubDto>().ReverseMap();
            CreateMap<Github, CreateGithubCommand>().ReverseMap();
            //Update
            CreateMap<Github, UpdatedGithubDto>().ReverseMap();
            CreateMap<Github, UpdateGithubCommand>().ReverseMap();
            //Delete
            CreateMap<Github, DeletedGithubDto>().ReverseMap();
            CreateMap<Github, DeleteGithubCommand>().ReverseMap();
            //GetList
            CreateMap<Github, GetListGithubDto>().ForMember(x => x.Email, opt => opt.MapFrom(x => x.Developer.Email)).ReverseMap();
            CreateMap<IPaginate<Github>, GithubListModel>().ReverseMap();
            //GetByGithubId
            CreateMap<Github, GetByGithubIdDto>().ForMember(x => x.Email, opt => opt.MapFrom(x => x.Developer.Email)).ReverseMap();
            CreateMap<Github, GetByGithubIdQuery>().ReverseMap();
        }
    }
}
