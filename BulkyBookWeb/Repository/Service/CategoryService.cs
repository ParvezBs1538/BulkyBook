using BulkyBookWeb.Data;
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

        #region GetByID
        public async Task<T> GetCategoryById(T id)
        {
            var category = await dbSet.FindAsync(id);

            return category;
        }
        #endregion

        #region GetAllData
        public async Task<IEnumerable<T>> GetCategory()
        {
            IEnumerable<T> data = await dbSet.ToListAsync();

            return data;
        }
        #endregion

        #region AddCategory
        public async Task<T> AddCategory(T category)
        {
            await dbSet.AddAsync(category);
            await context.SaveChangesAsync();

            return category;
        }
        #endregion

        #region DeleteCategoryGet
        public async Task<T> DeleteCategoryGet(int id)
        {
            var data = await dbSet.FindAsync(id);

            return data;
        }
        #endregion

        #region DeleteCategoryPost
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
        #endregion

        #region EditCategory

        public async Task<T> EditCategory(int id)
        {
            var data = await dbSet.FindAsync(id);

            return data;
        }

        #endregion

        #region UpdateCategory
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

        #endregion

        #region GetDetails

        public async Task<T> GetDetails(int id)
        {
            var data = await dbSet.FindAsync(id);

            return data;
        }
        #endregion
    }
}
