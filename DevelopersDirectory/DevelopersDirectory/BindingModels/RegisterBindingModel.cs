using System.ComponentModel.DataAnnotations;

namespace DevelopersDirectory.BindingModels
{
    public class RegisterBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ComparePassword { get; set; }
    }
}