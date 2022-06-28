using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ponya_Back.DAL;
using Ponya_Back.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        // GET: BlogController
        public ActionResult Index()
        {
            return View(_context.Blogs.Include(x=>x.BlogCategory).ToList());
        }

       

        // GET: BlogController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _context.BlogCategories.Where(c => c.IsDeleted == false).ToList();
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            ViewBag.Categories = _context.BlogCategories.Where(c => c.IsDeleted == false).ToList();
            if (!ModelState.IsValid) return BadRequest();
            if (blog.Photo != null)
            {
                if (blog.Photo.ContentType != "image/jpg"
                    && blog.Photo.ContentType != "image/png"
                    && blog.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png and .webp");
                    return View(blog);
                }
                if (blog.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(blog);
                }
                string fileName = blog.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newFileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    blog.Photo.CopyTo(stream);
                }
                blog.Image = newFileName;
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: BlogController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = _context.BlogCategories.Where(c => c.IsDeleted == false).ToList();
            Blog blog = _context.Blogs.Include(x => x.BlogCategory).FirstOrDefault(x => x.Id == id);
            if (blog == null) return RedirectToAction("Index", "404");
            return View(blog);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Blog blog)
        {
            ViewBag.Categories = _context.BlogCategories.Where(c => c.IsDeleted == false).ToList();
            Blog existblog = _context.Blogs.Include(x => x.BlogCategory).FirstOrDefault(x => x.Id == blog.Id);
            if (existblog == null) return RedirectToAction("Index", "404");
            string newfileName = null;
            if (existblog.Photo != null)
            {
                if (blog.Photo.ContentType != "image/jpeg"
                    && blog.Photo.ContentType != "image/png"
                    && blog.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png");
                    return View(blog);
                }
                if (blog.Photo.Length / 1024 > 2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(blog);
                }
                string fileName = blog.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                newfileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newfileName);
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    blog.Photo.CopyTo(fs);
                }
            }
            if (newfileName != null)
            {
                string deletepath = Path.Combine(_env.WebRootPath, "assets", "uploadimg", existblog.Image);
                if (System.IO.File.Exists(deletepath))
                {
                    System.IO.File.Delete(deletepath);
                }
                existblog.Image = newfileName;
            }
            existblog.Title = blog.Title;
            existblog.Description = blog.Description;
            existblog.IsDeleted = blog.IsDeleted;
            existblog.CategoryId = blog.CategoryId;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: BlogController/Delete/5
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Blog blog = _context.Blogs.Find(id);
            if (blog is null) return RedirectToAction("Index", "404");
            if (blog.IsDeleted == false)  blog.IsDeleted = true;
            blog.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PermaDelete(int id)
        {
            Blog blog = _context.Blogs.Find(id);
            if (blog == null) return RedirectToAction("Index", "404");
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
