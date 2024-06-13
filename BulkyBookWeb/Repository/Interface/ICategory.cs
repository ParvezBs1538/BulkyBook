using BulkyBookWeb.Models;
using System.Runtime.InteropServices;
namespace BulkyBookWeb.Repository.Interface
{
    public interface ICategory<T> where T : class
    {
        Task<T> GetCategoryById(T id);

        Task<IEnumerable<T>> GetCategory();

        Task<T> AddCategory(T category);

        Task<T> EditCategory(int id);
        Task<bool> UpdateCategory(T category);

        Task<T> DeleteCategoryGet(int id);
        Task<bool> DeleteCategoryPost(T category);

        Task<T> GetDetails(int id);
    }
}
