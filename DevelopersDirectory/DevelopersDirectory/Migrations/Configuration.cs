using DevelopersDirectory.Models;

namespace DevelopersDirectory.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DevelopersDirectory.DAL.DirectoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DevelopersDirectory.DAL.DirectoryContext context)
        {
            var developerCount = context.Developers.Count();

            if (developerCount == 0)
            {
                context.Categories.AddOrUpdate(e => e.CategoryId,
                    new Category
                    {
                        CategoryId = 1,
                        CategoryTitle = "Front-End Developer"
                    },
                    new Category
                    {
                        CategoryId = 2,
                        CategoryTitle = "Back-End Developer"
                    },
                    new Category
                    {
                        CategoryId = 3,
                        CategoryTitle = "Fullstack Developer"
                    },

                    new Category
                    {
                        CategoryId = 4,
                        CategoryTitle = "Data Scientist"
                    });

                context.Developers.AddOrUpdate(e => e.EmailAddress,
                    new Developer
                    {
                        GithubId = "https://github.com/folaraz",
                        Name = "Olajide Abdulrazzaq Folarin",
                        CategoryId = 4,
                        EmailAddress = "folaraz11@gmail.com"

                    },
                    new Developer
                    {
                        GithubId = "https://github.com/SeunMatt",
                        Name = "Seun Matt",
                        CategoryId = 3,
                        TwitterHandle = "https://twitter.com/seunmatt2"

                    },
                    new Developer
                    {
                        GithubId = "https://github.com/flipponachi",
                        Name = "Dayo Ojo Jnr",
                        CategoryId = 3,
                        EmailAddress = "dayoojojnr@hotmail.com",
                        TwitterHandle = "https://twitter.com/flipponachi"

                    });
                context.SaveChanges();
            }
        }
    }
}
