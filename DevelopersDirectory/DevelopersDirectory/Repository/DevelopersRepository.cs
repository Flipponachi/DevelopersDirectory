using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevelopersDirectory.BindingModels;
using DevelopersDirectory.DAL;
using DevelopersDirectory.Interfaces;
using DevelopersDirectory.Models;

namespace DevelopersDirectory.Repository
{
    public class DevelopersRepository : IDevelopersRepository
    {
        private readonly DirectoryContext _context;

        public DevelopersRepository()
        {
            _context = new DirectoryContext();
        }

        //Get all directory enty
        public async Task<IQueryable<Developer>> ListOfDevelopers()
        {
            var entries = await _context.Developers.ToListAsync();
            return entries.AsQueryable();
        }

        //Get a single Entry details
        public async Task<Developer> SingleDeveloper(int? id)
        {
            var entry = await _context.Developers.FirstOrDefaultAsync(e => e.DeveloperId == id);
            if(entry == null)
                throw new Exception("No Record Found");

            return entry;
        }

        public async Task CreateDeveloperEntry(DeveloperDirectoryBindingModel model)
        {
            var directory = Mapper.Map<Developer>(model);
            _context.Developers.Add(directory);
            var saved = await _context.SaveChangesAsync();
        }

        public async Task EditDeveloperEntry(int? id, DeveloperDirectoryBindingModel model)
        {
            var member = await SingleDeveloper(id);

            if(member == null)
                throw new Exception("Developer entry not found");
            
            _context.Entry(member).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteDeveloper(int? id)
        {
            var directoryEntry = await SingleDeveloper(id);
            _context.Developers.Remove(directoryEntry);
            await _context.SaveChangesAsync();
        }
    }
}