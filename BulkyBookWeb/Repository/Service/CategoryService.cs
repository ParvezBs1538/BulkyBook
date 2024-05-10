using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Repository.Service
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext context;
        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Category>> GetCategory()
        {
            var data = await context.Categories.ToListAsync();
            return data;
        }

        public async Task<int> AddCategory(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return category.Id;
        }

        public Task<bool> DeleteRecord(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRecord(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
