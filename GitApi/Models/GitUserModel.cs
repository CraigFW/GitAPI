using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitApi.Models
{
    public class GitUserModel
    {
        public string Login { get; set; }
        public int ID { get; set; }
        public string Avatar_Url { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Repos_Url { get; set; }
        public string Location { get; set; }
    }
}