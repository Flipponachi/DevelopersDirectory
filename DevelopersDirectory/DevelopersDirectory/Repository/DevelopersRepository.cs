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
        public async Task<DeveloperDirectoryBindingModel> SingleDeveloper(int? id)
        {
            var entry = await _context.Developers.FirstOrDefaultAsync(e => e.DeveloperId == id);
            var dto = Mapper.Map<DeveloperDirectoryBindingModel>(entry);
            if(entry == null)
                throw new Exception("No Record Found");

            return dto;
        }

        public async Task CreateDeveloperEntry(DeveloperDirectoryBindingModel model)
        {
            var directory = Mapper.Map<Developer>(model);
            _context.Developers.Add(directory);
            var saved = await _context.SaveChangesAsync();
        }

        public async Task EditDeveloperEntry(int? id, DeveloperDirectoryBindingModel model)
        {
            var developer = await _context.Developers.FindAsync(id);
            var editedDeveloper = Mapper.Map<DeveloperDirectoryBindingModel, Developer>(model, developer);
            if(developer == null)
                throw new Exception("Developer entry not found");
            
            // _context.Entry(editedDeveloper).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteDeveloper(int? id)
        {
            var directoryEntry = await _context.Developers.FindAsync(id);
            _context.Developers.Remove(directoryEntry);
            await _context.SaveChangesAsync();
        }

        //Get all developers with their categories
        public async Task<IQueryable<Category>> DeveloperCategories()
        {
            var categories = await _context.Categories.Include(e => e.Developers).ToListAsync();
            return categories.AsQueryable();
        }

        public async Task<Category> DeveloperCategories(int? id)
        {
            var category = await _context.Categories
                .Include(e => e.Developers)
                .FirstAsync(e => e.CategoryId == id);

            return category;
        }

        public async Task<Category> DeveloperCategories(string categoryName)
        {
            var category = await _context.Categories
                .Include(e => e.Developers)
                .FirstAsync(e => e.CategoryTitle == categoryName);

            return category;
        }
    }
}