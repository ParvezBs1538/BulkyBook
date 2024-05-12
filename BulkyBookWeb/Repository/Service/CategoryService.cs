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

        #region GetCategoryById
        public async Task<Category> GetCategoryById(int id)
        {
            var data = await context.Categories.FindAsync(id);
            return data;
        }
        #endregion

        #region GetCategory
        public async Task<IEnumerable<Category>> GetCategory()
        {
            var data = await context.Categories.OrderBy(x => x.DisplayOrder).ToListAsync();
            return data;
        }
        #endregion

        #region AddCategory
        public async Task<int> AddCategory(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return category.Id;
        }
        #endregion


        #region UpdateRecord
        public async Task<bool> UpdateRecord(Category category)
        {
            bool status = false;
            if (category != null)
            {
                context.Categories.Update(category);
                await context.SaveChangesAsync();
                status = true;
            }
            return status;
        }
        #endregion

        public async Task<bool> DeleteRecord(int id)
        {
            bool status = false;
            if (id != 0)
            {
                var data = await GetCategoryById(id);
                if (data != null)
                {
                    context.Categories.Remove(data);
                    await context.SaveChangesAsync();
                    status = true;
                }
            }
            return status;
        }
    }
}
