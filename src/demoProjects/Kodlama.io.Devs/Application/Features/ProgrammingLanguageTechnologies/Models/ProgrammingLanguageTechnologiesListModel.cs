using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Models
{
    public class ProgrammingLanguageTechnologiesListModel
    {
        public IList<GetListProgrammingLanguageTechnologiesDto> Items { get; set; }
    }
}
