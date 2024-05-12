using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory<Category> category;
        public CategoryController(ICategory<Category> category)
        {
            this.category = category;
        }

        #region View all data
        public async Task<IActionResult> Index(string search)
        {
            //var data = await CategoryRepo.GetCategory();
            IEnumerable<Category> data = await category.GetCategory();
            if (!string.IsNullOrEmpty(search))
            {
                //data = data.Where(x => x.Name == search).OrderBy(x => x.DisplayOrder).ToList(); // search by exact name
                data = data.Where(x => x.Name.Contains(search)).OrderBy(x => x.DisplayOrder).ToList(); // search by any character
            }
            return View(data);
        }
        #endregion

        #region get create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        #endregion

        #region post create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
			{
                await category.AddCategory(obj);
                TempData["success"] = "Category created successfully";

                return RedirectToAction("Index");
            }

			return View(obj);
		}
        #endregion

        #region get delete
        //GET
        public async Task<IActionResult> Delete(int id)
        {
            Category categoryObj = new Category();

            if (id == 0)
            {
                return BadRequest();
            }

            categoryObj = await category.DeleteCategoryGet(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(categoryObj);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Delete(Category categoryObj)
        {

            if (!ModelState.IsValid)
            {
                bool status = await category.DeleteCategoryPost(categoryObj);
                if (status == false)
                {
                    TempData["error"] = "Deleted Performed Unsuccessfully";
                }
                else
                {
                    TempData["success"] = "Deleted successfully";
                }

                return RedirectToAction("Index");
            }

            return View(category);
        }
        #endregion


        //GET
        public async Task<IActionResult> Edit(int id)
        {
            Category categoryObj = new Category();

            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                categoryObj = await category.EditCategory(id);
                if (category == null)
                {
                    return NotFound();
                }
            }
            return View(categoryObj);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                bool data = await category.UpdateCategory(obj);
                if (data == true)
                {
                    TempData["success"] = "Edited successfully Updated";
                }
                else
                {
                    TempData["error"] = "Category not Updated";
                }
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        #region details
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await category.GetDetails(id);

            return View(item);
        }
        #endregion
    }
}
