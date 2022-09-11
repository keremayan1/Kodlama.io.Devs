using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Rules
{
    public class DeveloperBusinessRules
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperBusinessRules(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }
        public async Task DeveloperEmailCantDuplicatedWhenInserted(string email)
        {
            var result = await _developerRepository.GetAsync(x => x.Email.ToLower() == email.ToLower());
            if (result!=null)
                throw new BusinessException("Email is exist in system");
            
        }
        public void DeveloperShouldExist(Developer developer)
        {
            if (developer==null)
                throw new BusinessException("developer hasnt in the system");
            
        }
        public void UserCredentialsShouldMatch(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var result = HashingHelper.VerifyPasswordHash(password,passwordHash, passwordSalt);
            if (!result)
                throw new BusinessException("Wrong Email and Password");
                
        }
    }
}
