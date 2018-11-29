using DevelopersDirectory.Interfaces;

namespace DevelopersDirectory.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDevelopersRepository DevelopersRepository { get; set; }
        
        public UnitOfWork()
        {
            
        }
    }
}