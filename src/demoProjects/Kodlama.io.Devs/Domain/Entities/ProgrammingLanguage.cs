using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; }
        public List<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }
        public ProgrammingLanguage()
        {

        }
        public ProgrammingLanguage(int id,string name):this()
        {
            Id = id;
            Name = name;
        }
    }
}
