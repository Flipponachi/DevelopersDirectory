using System.Threading.Tasks;

namespace DevelopersDirectory.Interfaces
{
    public interface IUnitOfWork
    {
        Task Save();
        IDevelopersRepository DevelopersRepository { get; set; }
    }
}