using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Repository.Service
{
    public class CategoryService<T> : ICategory<T> where T : class
    {
        private readonly ApplicationDbContext context;
        DbSet<T> dbSet;
        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<T> GetCategoryById(T id)
        {
            var category = await dbSet.FindAsync(id);

            return category;
        }

        public async Task<IEnumerable<T>> GetCategory()
        {
            IEnumerable<T> data = await dbSet.ToListAsync();

            return data;
        }

        public async Task<T> AddCategory(T category)
        {
            await dbSet.AddAsync(category);
            await context.SaveChangesAsync();

            return category;
        }

        public async Task<T> DeleteCategoryGet(int id)
        {
            var data = await dbSet.FindAsync(id);

            return data;
        }

        public async Task<bool> DeleteCategoryPost(T category)
        {
            var status = false;

            if (category != null)
            {
                dbSet.Remove(category);
                await context.SaveChangesAsync();
                status = true;
            }

            return status;
        }

        public async Task<T> EditCategory(int id)
        {
            var data = await dbSet.FindAsync(id);
            return data;
        }

        public async Task<bool> UpdateCategory(T category)
        {
            bool status = false;

            if (category != null)
            {
                context.Update(category);
                await context.SaveChangesAsync();
                status = true;
            }

            return status;
        }

        public async Task<T> GetDetails(int id)
        {
            var data = await dbSet.FindAsync(id);
            return data;
        }

        /*
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
        */
    }
}
