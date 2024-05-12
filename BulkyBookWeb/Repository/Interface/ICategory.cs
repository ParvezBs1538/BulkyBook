using BulkyBookWeb.Models;
using System.Runtime.InteropServices;

namespace BulkyBookWeb.Repository.Interface
{
    public interface ICategory<T> where T : class
    {
        //Task<Category> GetCategoryById(int id);
        Task<T> GetCategoryById(T id);


        //Task<IEnumerable<Category>> GetCategory();
        Task<IEnumerable<T>> GetCategory();


        //Task<int> AddCategory(Category category);
        Task<T> AddCategory(T category);


        //Task<bool> UpdateRecord(Category category);
        //Task<T> UpdateRecord(T category);
        Task<T> EditCategory(int id);
        Task<bool> UpdateCategory(T category);


        //Task<bool> DeleteRecord(int id);
        Task<T> DeleteCategoryGet(int id);
        Task<bool> DeleteCategoryPost(T category);

        Task<T> GetDetails(int id);
    }
}
