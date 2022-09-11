using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Command.RegisterDeveloper
{
    public class RegisterDeveloperCommand:UserForRegisterDto,IRequest<TokenDto>
    {
        public class RegisterDeveloperCommandHandler : IRequestHandler<RegisterDeveloperCommand, TokenDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public RegisterDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<TokenDto> Handle(RegisterDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _developerBusinessRules.DeveloperEmailCantDuplicatedWhenInserted(request.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                
                var mappedDeveloper = _mapper.Map<Developer>(request);
                mappedDeveloper.PasswordHash = passwordHash;
                mappedDeveloper.PasswordSalt = passwordSalt;
                
                var addResult = await _developerRepository.AddAsync(mappedDeveloper);
                
                var token = _tokenHelper.CreateToken(mappedDeveloper, new List<OperationClaim>());
                
                var mappedToken = _mapper.Map<TokenDto>(token);
                return mappedToken;

            }
        }
    }
}
