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
	}
}
