using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitApi.Models
{
    public class RepoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GitUserModel Owner { get; set; }
        public string Description { get; set; }
        public string Html_Url { get; set; }
        public int Stargazers_Count { get; set; }
    }
}