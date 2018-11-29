using System;
using System.Threading.Tasks;
using DevelopersDirectory.Interfaces;

namespace DevelopersDirectory.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DirectoryContext _context;

        public IDevelopersRepository DevelopersRepository { get; set; }
        
        public UnitOfWork(IDevelopersRepository developersRepository)
        {
            DevelopersRepository = developersRepository;
            _context = new DirectoryContext();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}