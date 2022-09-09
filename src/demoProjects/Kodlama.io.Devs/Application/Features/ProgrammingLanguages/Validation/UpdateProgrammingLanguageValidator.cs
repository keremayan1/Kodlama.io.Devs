using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Validation
{
    public class UpdateProgrammingLanguageValidator:AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty().WithMessage("Isim bos olamaz!");
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Isim en az 2 karakterli olmalidir");
        }
    }
}
