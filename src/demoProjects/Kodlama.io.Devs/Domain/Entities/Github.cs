using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Github:Entity
    {
        public int DeveloperId { get; set; }
        public string GithubAddressName { get; set; }
        public virtual Developer Developer { get; set; }
        public Github()
        {

        }
        public Github(int id,int developerId, string githubAddressesName):this()
        {
            Id = id;
            DeveloperId = developerId;
            GithubAddressName = githubAddressesName;
        }
    }
}
