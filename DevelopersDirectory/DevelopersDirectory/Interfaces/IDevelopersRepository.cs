using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopersDirectory.BindingModels;
using DevelopersDirectory.Models;

namespace DevelopersDirectory.Interfaces
{
    public interface IDevelopersRepository
    {
        List<DeveloperDirectoryBindingModel> ListOfDevelopers();
        Task<DeveloperDirectoryBindingModel> SingleDeveloper(int? id);

        Task CreateDeveloperEntry(DeveloperDirectoryBindingModel model);

        Task EditDeveloperEntry(int? id, DeveloperDirectoryBindingModel model);
        Task DeleteDeveloper(int? id);
        Task<IQueryable<Category>> DeveloperCategories();
        Task<Category> DeveloperCategories(int? id);
        Task<Category> DeveloperCategories(string categoryName);
    }
}