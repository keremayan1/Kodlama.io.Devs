using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Command.LoginDeveloper
{
    public class LoginDeveloperCommand:UserForLoginDto,IRequest<TokenDto>
    {
        public class LoginDeveloperCommandHandler : IRequestHandler<LoginDeveloperCommand, TokenDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public LoginDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<TokenDto> Handle(LoginDeveloperCommand request, CancellationToken cancellationToken)
            {
                var developer = await _developerRepository.GetAsync2(u => u.Email.ToLower() == request.Email.ToLower(),
                                                                include:m=>m.Include(c=>c.UserOperationClaims).ThenInclude(x=>x.OperationClaim));
                var operationClaim = new List<OperationClaim>();
                foreach (var userOperationClaim in developer.UserOperationClaims)
                {
                    operationClaim.Add(userOperationClaim.OperationClaim);
                }
                _developerBusinessRules.DeveloperShouldExist(developer);
                _developerBusinessRules.UserCredentialsShouldMatch(request.Password, developer.PasswordHash, developer.PasswordSalt);
               
                var token = _tokenHelper.CreateToken(developer, operationClaim);
                
                var result = _mapper.Map<TokenDto>(token);
                return result;
                
                
            }
        }
    }
}
