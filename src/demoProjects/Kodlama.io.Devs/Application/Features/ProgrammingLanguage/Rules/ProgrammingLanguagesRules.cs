using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguage.Rules
{
    public class ProgrammingLanguagesRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguagesRepository;

        public ProgrammingLanguagesRules(IProgrammingLanguageRepository programmingLanguagesRepository)
        {
            _programmingLanguagesRepository = programmingLanguagesRepository;
        }
        public async Task ProgrammingLanguageNameCantDuplicatedWhenInserted(string name)
        {
            var result = await _programmingLanguagesRepository.GetListAsync(x => x.Name.ToLower() == name.ToLower());
            if (result.Items.Any())
                throw new BusinessException("Program Language is exist");
        }
        public void ProgrammingLanguageShouldExistsWhenRequested(Domain.Entities.ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null)
                throw new BusinessException("Requested Program Language does not exist");
        }
    }
}
