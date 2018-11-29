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

        public async Task EditDeveloperEntry(Developer model)
        {
            var developer = await _context.Developers.FindAsync(model.DeveloperId);

            if(developer == null)
                throw new Exception("Developer entry not found");

            //_context.Developers.Add(developer);
             _context.Entry(developer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteDeveloper(int? id)
        {
            var directoryEntry = await SingleDeveloper(id);
            _context.Developers.Remove(directoryEntry);
            await _context.SaveChangesAsync();
        }

        //Get all developers with their categories
        public async Task<IQueryable<Category>> DeveloperCategories()
        {
            var categories = await _context.Categories.Include(e => e.Developers).ToListAsync();
            return categories.AsQueryable();
        }
    }
}