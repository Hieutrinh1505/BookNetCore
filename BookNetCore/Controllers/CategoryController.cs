using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookNetCore.Data;
using BookNetCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookNetCore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category? obj)
        {
            //List<string>? names = _db.Categories.Select(a => a.Name.ToLower()).ToList();
            //if(!String.IsNullOrEmpty(obj.Name.ToLower()))
            //{
            //    ModelState.AddModelError("name", "This name is already existed.");
            //}

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name");
            }

            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);           
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null) return NotFound();

            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null) return NotFound();
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //List<string>? names = _db.Categories.Select(a => a.Name.ToLower()).ToList();
            //if(!String.IsNullOrEmpty(obj.Name.ToLower()))
            //{
            //    ModelState.AddModelError("name", "This name is already existed.");
            //}

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}

