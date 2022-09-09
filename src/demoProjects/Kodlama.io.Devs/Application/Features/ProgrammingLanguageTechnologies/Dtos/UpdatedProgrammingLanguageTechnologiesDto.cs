using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Dtos
{
    public class UpdatedProgrammingLanguageTechnologiesDto
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguageTechnologiesName { get; set; }

    }
}
