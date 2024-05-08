using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string search)
        {
            var item = context.Products.OrderBy(x => x.Price).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                item = item.Where(c => c.Name.Contains(search)).OrderBy(x => x.Price).ToList();
            }

            return View(item);
        }
		public IActionResult Create()
		{
			return View();
		}
		// post
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Product obj)
		{
			if (ModelState.IsValid)
			{
				context.Products.Add(obj);
				context.SaveChanges();
				TempData["success"] = "Product created successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}
		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var item = context.Products.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			return View(item);
		}
		// post
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			var item = context.Products.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			context.Products.Remove(item);
			context.SaveChanges();
			TempData["success"] = "Category Delete successfully";
			return RedirectToAction("Index");
		}
	}
}
