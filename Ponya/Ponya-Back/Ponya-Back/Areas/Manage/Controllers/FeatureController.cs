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
    public class FeatureController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public FeatureController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        // GET: FeatureController
        public ActionResult Index()
        {
            return View(_context.Features.ToList());
        }

        // GET: FeatureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeatureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Features features)
        {
            if (!ModelState.IsValid) return View(features);
            if(features.Photo != null)
            {
                if(features.Photo.ContentType != "image/jpeg"
                    && features.Photo.ContentType != "image/png"
                    && features.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png and .webp");
                    return View(features);
                }
                if(features.Photo.Length /1024 >2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(features);
                }
                string fileName = features.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newFileName);
                using(FileStream fs = new FileStream(path,FileMode.Create))
                {
                    features.Photo.CopyTo(fs);
                }
                features.Image = newFileName;
                _context.Features.Add(features);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: FeatureController/Edit/5
        public ActionResult Edit(int id)
        {
            Features features = _context.Features.FirstOrDefault(x => x.Id == id);
            if (features is null) return RedirectToAction("Index", "404");
            return View(features);
        }

        // POST: FeatureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Features features)
        {
            Features existfeature = _context.Features.FirstOrDefault(x => x.Id == features.Id);
            if (existfeature is null) return RedirectToAction("Index", "404");
            string newFileName = null;

            if (features.Photo != null)
            {
                if (features.Photo.ContentType != "image/jpeg"
                    && features.Photo.ContentType != "image/png"
                    && features.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png");
                    return View(features);
                }
                if (features.Photo.Length / 1024 > 2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(features);
                }
                string fileName = features.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                newFileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "image", newFileName);
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    features.Photo.CopyTo(fs);
                }
            }
            if (newFileName != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "assets", "image", existfeature.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                existfeature.Image = newFileName;
            }

            existfeature.Title = features.Title;
            existfeature.Subtitle = features.Subtitle;
            existfeature.Icon = features.Icon;
            existfeature.IsDeleted = features.IsDeleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        // GET: FeatureController/Delete/5
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Features features = _context.Features.Find(id);
            if (features is null) return RedirectToAction("Index", "404");
            if(features.IsDeleted==false)
            {
                features.IsDeleted = true;
            }
            features.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: FeatureController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult PermaDelete(int id)
        {
            Features features = _context.Features.Find(id);
            if (features is null) return RedirectToAction("Index", "404");
            _context.Features.Remove(features);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
