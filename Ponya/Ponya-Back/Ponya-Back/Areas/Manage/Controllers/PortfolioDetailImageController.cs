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
    public class PortfolioDetailImageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PortfolioDetailImageController(IWebHostEnvironment env,AppDbContext context)
        {
            _context = context;
            _env = env;
        }
        // GET: PortfolioDetailImageController
        public ActionResult Index()
        {
            return View(_context.PortfolioDetailImages.ToList());
        }

       

        // GET: PortfolioDetailImageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortfolioDetailImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PortfolioDetailImage detailImage )
        {
            if (!ModelState.IsValid) return BadRequest();
            if(detailImage.Photo != null)
            {
                if(detailImage.Photo.ContentType != "image/jpg"
                    && detailImage.Photo.ContentType != "image/png"
                    && detailImage.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png and .webp");
                    return View(detailImage);
                }
                if(detailImage.Photo.Length/1024>2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(detailImage);
                }
                string fileName = detailImage.Photo.FileName;
                if(detailImage.Photo.Length>64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                string newfileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newfileName);
                using(FileStream stream = new FileStream(path,FileMode.Create))
                {
                    detailImage.Photo.CopyTo(stream);
                }
                detailImage.Image = newfileName;
                _context.PortfolioDetailImages.Add(detailImage);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: PortfolioDetailImageController/Edit/5
        public ActionResult Edit(int id)
        {
            PortfolioDetailImage detailImage = _context.PortfolioDetailImages.FirstOrDefault(x => x.Id == id);
            if (detailImage == null) return RedirectToAction("Index", "404");
            return View(detailImage);
        }

        // POST: PortfolioDetailImageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(  PortfolioDetailImage detailImage)
        {
            PortfolioDetailImage existimage = _context.PortfolioDetailImages.FirstOrDefault(x => x.Id == detailImage.Id);
            if (existimage is null) return RedirectToAction("Index", "404");
            string newfileName = null;
            if(existimage.Photo != null)
            {
                if (detailImage.Photo.ContentType != "image/jpg"
                    && detailImage.Photo.ContentType != "image/png"
                    && detailImage.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png and .webp");
                    return View(detailImage);
                }
                if (detailImage.Photo.Length / 1024 > 2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(detailImage);
                }
                string fileName = detailImage.Photo.FileName;
                if (detailImage.Photo.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                newfileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newfileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    detailImage.Photo.CopyTo(stream);
                }        
            }
            if(newfileName != null)
            {
                string deletepath = Path.Combine(_env.WebRootPath, "assets", "uploadimg", existimage.Image);
                if(System.IO.File.Exists(deletepath))
                {
                    System.IO.File.Delete(deletepath);
                }
                existimage.Image = newfileName;
            }
            existimage.IsDeleted = detailImage.IsDeleted;
            return RedirectToAction(nameof(Index));
        }

        // GET: PortfolioDetailImageController/Delete/5
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            PortfolioDetailImage detailImage = _context.PortfolioDetailImages.Find(id);
            if (detailImage == null) return RedirectToAction("Index", "404");
            if (detailImage.IsDeleted == false) detailImage.IsDeleted = true;
            detailImage.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: PortfolioDetailImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PermaDelete(int id)
        {
            PortfolioDetailImage detailImage = _context.PortfolioDetailImages.Find(id);
            if (detailImage == null) return RedirectToAction("Index", "404");
            _context.PortfolioDetailImages.Remove(detailImage);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
