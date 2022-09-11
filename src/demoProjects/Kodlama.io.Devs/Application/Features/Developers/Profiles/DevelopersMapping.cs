using Application.Features.Developers.Command.RegisterDeveloper;
using Application.Features.Developers.Dtos;
using AutoMapper;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Profiles
{
    public class DevelopersMapping:Profile
    {
        public DevelopersMapping()
        {
            CreateMap<Developer, RegisterDeveloperCommand>().ReverseMap();
            CreateMap<AccessToken, TokenDto>().ReverseMap();
        }
    }
}
