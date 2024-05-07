using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            //var item = context.Categories.ToList();
            IEnumerable<Category> item = context.Categories.ToList();  // IEnumerable-> represents a sequence of elements
            return View(item);
        }
        // Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // post
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(Category obj)
		{
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
			{
				context.Categories.Add(obj);
				context.SaveChanges();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		// Get
		[HttpGet]
		public IActionResult Edit(int? id)
		{
            if (id == null || id == 0)
			{
				return NotFound();
			}
			//var item = context.Categories.Single(x => x.Id == id); // if no element found return exception
			//var item = context.Categories.SingleOrDefault(x => x.Id == id); // if no element found return empty (it throw exception if more than element found)
			//var item = context.Categories.FirstOrDefault(x => x.Id == id); // if found more than one then return first element
			var item = context.Categories.Find(id);
			if (item == null)
			{
				return NotFound();
			}
            return View(item);
		}
		// post
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
			}
			if (ModelState.IsValid)
			{
				context.Categories.Update(obj);
				context.SaveChanges();
				TempData["success"] = "Category Updated successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

        // Get
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = context.Categories.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        // post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var item = context.Categories.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            context.Categories.Remove(item);
            context.SaveChanges();
            TempData["success"] = "Category Delete successfully";
            return RedirectToAction("Index");
        }
    }
}
