using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Dtos
{
    public class GetListProgrammingLanguageTechnologiesDto
    {
        public int Id { get; set; }
        public string ProgrammingLanguageName { get; set; }
        public string ProgrammingLanguageTechnologyName { get; set; }

    }
}
