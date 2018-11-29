using System.ComponentModel.DataAnnotations;

namespace DevelopersDirectory.BindingModels
{
    public class DeveloperDirectoryBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }


        public string TwitterHandle { get; set; }
        public string GithubId { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }
}