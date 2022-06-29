using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ponya_Back.DAL;
using Ponya_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BlogCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public BlogCategoryController(AppDbContext context)
        {
            _context = context;
        }
        // GET: BlogCategoryController
        public ActionResult Index()
        {
            return View(_context.BlogCategories.ToList());
        }

        

        // GET: BlogCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogCategory blogCategory)
        {
            if (blogCategory == null) return BadRequest();
            _context.BlogCategories.Add(blogCategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: BlogCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            BlogCategory blogCategory = _context.BlogCategories.FirstOrDefault(x => x.Id == id);
            if (blogCategory is null) return RedirectToAction("Index", "404");
            return View(blogCategory);
        }

        // POST: BlogCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( BlogCategory blogCategory)
        {
            BlogCategory existblog = _context.BlogCategories.FirstOrDefault(x => x.Id == blogCategory.Id);
            if (existblog == null) return RedirectToAction("Index", "404");
            existblog.CatogryName = blogCategory.CatogryName;
            existblog.IsDeleted = blogCategory.IsDeleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: BlogCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            BlogCategory blogCategory = _context.BlogCategories.Find(id);
            if (blogCategory is null) return RedirectToAction("Index", "404");
            if (blogCategory.IsDeleted == true) blogCategory.IsDeleted = false;
            blogCategory.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: BlogCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PermaDelete(int id)
        {
            BlogCategory blogCategory = _context.BlogCategories.Find(id);
            if (blogCategory is null) return RedirectToAction("Index", "404");
            _context.BlogCategories.Remove(blogCategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
