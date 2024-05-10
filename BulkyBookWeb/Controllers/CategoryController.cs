using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory CategoryRepo;
        public CategoryController(ICategory CategoryRepo)
        {
            this.CategoryRepo = CategoryRepo;
        }

        #region repo index
        public async Task<IActionResult> Index()
        {
            var data = await CategoryRepo.GetCategory();
            return View(data);
        }
        #endregion

        #region search by name
        //public IActionResult Index(string search)
        //{
        //    var item = context.Categories.OrderBy(x => x.DisplayOrder).ToList();

        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        item = item.Where(c => c.Name.Contains(search)).OrderBy(x => x.DisplayOrder).ToList();
        //    }

        //    return View(item);
        //}
        #endregion


        //public IActionResult Index()
        //{
        //    var item = context.Categories.ToList();
        //    IEnumerable<Category> item = context.Categories.OrderBy(x => x.DisplayOrder).ToList();  // IEnumerable-> represents a sequence of elements

        //    return View(item);
        //}

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
        public async Task<IActionResult> Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
			{
                await CategoryRepo.AddCategory(category);
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

			return View(category);
		}
        #endregion

        #region get edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Category category = new Category();
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    category = await CategoryRepo.GetCategoryById(id);
                    if (category == null)
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(category);
        }
        #endregion

        #region post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                else
                {
                    bool status = await CategoryRepo.UpdateRecord(category);
                    if (status)
                    {
                        TempData["success"] = "Category Updated successfully";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        #endregion

        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var item = context.Categories.Find(id);
        //    return View(item);
        //}

        //      // Get
        //      [HttpGet]
        //      public IActionResult Delete(int? id)
        //      {
        //          if (id == null || id == 0)
        //          {
        //              return NotFound();
        //          }
        //          var item = context.Categories.Find(id);
        //          if (item == null)
        //          {
        //              return NotFound();
        //          }
        //          return View(item);
        //      }
        //      // post
        //      [HttpPost, ActionName("Delete")]
        //      [ValidateAntiForgeryToken]
        //      public IActionResult DeletePost(int? id)
        //      {
        //          var item = context.Categories.Find(id);
        //          if (item == null)
        //          {
        //              return NotFound();
        //          }
        //          context.Categories.Remove(item);
        //          context.SaveChanges();
        //          TempData["success"] = "Category Delete successfully";
        //          return RedirectToAction("Index");
        //      }
    }
}
