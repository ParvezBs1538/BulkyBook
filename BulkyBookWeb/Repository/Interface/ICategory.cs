using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository.Interface
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<int> AddCategory(Category category);
        //Task<Category> GetDetails(int id);
        //Task<Category> GetUserById(int id);
        //Task<bool> UpdateRecord(Category category);
        //Task<bool> DeleteRecord(int id);
    }
}
