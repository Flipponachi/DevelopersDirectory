namespace DevelopersDirectory.BindingModels
{
    public class DeveloperDirectoryBindingModel
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string TwitterHandle { get; set; }
        public string GithubId { get; set; }

        public int CategoryId { get; set; }

    }
}