using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AboutUsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutUsController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET: AboutUsController
        public ActionResult Index()
        {
            return View(_context.AboutUs.ToList());
        }

       

        // GET: AboutUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AboutUs aboutUs)
        {
            if (!ModelState.IsValid) return BadRequest();
            if(aboutUs.Photo != null)
            {
                if(aboutUs.Photo.ContentType != "image/jpg"
                    && aboutUs.Photo.ContentType != "image/png"
                    && aboutUs.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png and .webp");
                    return View(aboutUs);
                }
                if (aboutUs.Photo.Length / 1024 > 2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(aboutUs);
                }
                string fileName = aboutUs.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                string newfileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newfileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    aboutUs.Photo.CopyTo(stream);
                }
                aboutUs.Image = newfileName;
                _context.AboutUs.Add(aboutUs);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: AboutUsController/Edit/5
        public ActionResult Edit(int id)
        {
            AboutUs aboutUs = _context.AboutUs.FirstOrDefault(x => x.Id == id);
            if (aboutUs is null) return RedirectToAction("Index", "404");
            return View(aboutUs);
        }

        // POST: AboutUsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( AboutUs aboutUs)
        {
            AboutUs existabout = _context.AboutUs.FirstOrDefault(x => x.Id == aboutUs.Id);
            if (existabout is null) return RedirectToAction("Index", "404");
            string newfileName = null;
            if (existabout.Photo != null)
            {
                if (aboutUs.Photo.ContentType != "image/jpg"
                    && aboutUs.Photo.ContentType != "image/png"
                    && aboutUs.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png and .webp");
                    return View(aboutUs);
                }
                if (aboutUs.Photo.Length / 1024 > 2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(aboutUs);
                }
                string fileName = aboutUs.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                newfileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newfileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    aboutUs.Photo.CopyTo(stream);
                } 
            }
            if(newfileName != null)
            {
                string deletepath = Path.Combine(_env.WebRootPath, "assets", "uploadimg", existabout.Image);
                if (System.IO.File.Exists(deletepath)) System.IO.File.Delete(deletepath);
                existabout.Image = newfileName;
            }
            existabout.Title1 = aboutUs.Title1;
            existabout.Title2 = aboutUs.Title2;
            existabout.Description = aboutUs.Description;
            existabout.IsDeleted = aboutUs.IsDeleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: AboutUsController/Delete/5
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            AboutUs aboutUs = _context.AboutUs.Find(id);
            if (aboutUs is null) return RedirectToAction("Index", "404");
            if (aboutUs.IsDeleted == false) aboutUs.IsDeleted = true;
            aboutUs.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: AboutUsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PermaDelete(int id)
        {
            AboutUs aboutUs = _context.AboutUs.Find(id);
            if (aboutUs is null) return RedirectToAction("Index", "404");
            _context.AboutUs.Remove(aboutUs);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
