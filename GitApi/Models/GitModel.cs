using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitApi.Models
{
    public class GitModel
    {
        public IEnumerable<RepoModel> Repos { get; set; }
        public GitUserModel User { get; set; }
    }
}