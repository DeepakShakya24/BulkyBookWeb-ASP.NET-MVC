using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories;
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(id);
            if (category==null)
            {
                return NotFound();
            }
            return View(category);
            
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (category.Category_Id==null || category.Category_Id==0)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
               
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        [HttpPost]
        public IActionResult Delete(int Category_Id)
        {
            if (Category_Id == 0)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(Category_Id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
