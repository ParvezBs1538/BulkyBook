using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository.Interface
{
    public interface ICategory
    {
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetCategory();
        Task<int> AddCategory(Category category);
        Task<bool> UpdateRecord(Category category);
        Task<bool> DeleteRecord(int id);
    }
}
