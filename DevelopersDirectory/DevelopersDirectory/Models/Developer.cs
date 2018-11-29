using System;
using System.Linq;
using System.Web;

namespace DevelopersDirectory.Models
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string TwitterHandle { get; set; }
        public string GithubId { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}