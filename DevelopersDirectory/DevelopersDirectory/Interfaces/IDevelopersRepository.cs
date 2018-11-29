using System.Linq;
using System.Threading.Tasks;
using DevelopersDirectory.BindingModels;
using DevelopersDirectory.Models;

namespace DevelopersDirectory.Interfaces
{
    public interface IDevelopersRepository
    {
        Task<IQueryable<Developer>> ListOfDevelopers();
        Task<Developer> SingleDeveloper(int? id);

        Task CreateDeveloperEntry(DeveloperDirectoryBindingModel model);

        Task EditDeveloperEntry(Developer model);
        Task DeleteDeveloper(int? id);
        Task<IQueryable<Category>> DeveloperCategories();
    }
}