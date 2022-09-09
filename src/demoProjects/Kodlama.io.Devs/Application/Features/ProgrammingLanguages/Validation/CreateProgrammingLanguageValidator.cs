using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Validation
{
    public class CreateProgrammingLanguageValidator:AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Isim bos olamaz!");
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Isim en az 2 karakterli olmalidir");
        }
    }
}
