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
    public class HeroController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public HeroController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        // GET: HeroController
        public ActionResult Index()
        {
            return View(_context.Heroes.ToList());
        }

        

        // GET: HeroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hero hero)
        {       
                if (!ModelState.IsValid) return BadRequest();
                if(hero.Photo != null)
                {
                    if(hero.Photo.ContentType != "image/jpg"
                        && hero.Photo.ContentType != "image/png"
                        && hero.Photo.ContentType != "image/webp")
                    {
                        ModelState.AddModelError("Photo", "Image can be only .jpeg or .png and .webp");
                        return View(hero);
                    }
                    if(hero.Photo.Length /1024 >200)
                    {
                        ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                        return View(hero);
                    }
                    string fileName = hero.Photo.FileName;
                    if (fileName.Length > 64)
                    {
                        fileName.Substring(fileName.Length - 64, 64);
                    }
                    string newFileName = Guid.NewGuid().ToString() + fileName;
                    string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newFileName);
                    using(FileStream stream = new FileStream(path,FileMode.Create))
                    {
                        hero.Photo.CopyTo(stream);
                    }
                    hero.Image = newFileName;
                    _context.Heroes.Add(hero);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();       
        }

        // GET: HeroController/Edit/5
        public ActionResult Edit(int id)
        {
            Hero hero = _context.Heroes.FirstOrDefault(x => x.Id == id);
            if (hero == null) return RedirectToAction("Index", "404");
            return View(hero);
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Hero hero)
        {
            Hero existhero = _context.Heroes.FirstOrDefault(x => x.Id == hero.Id);
            if (existhero == null) return RedirectToAction("Index", "404");
            string newfileName = null;
            if(existhero.Photo != null)
            {
                if (hero.Photo.ContentType != "image/jpeg"
                    && hero.Photo.ContentType != "image/png"
                    && hero.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png");
                    return View(hero);
                }
                if (hero.Photo.Length / 1024 > 2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(hero);
                }
                string fileName = hero.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                newfileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newfileName);
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    hero.Photo.CopyTo(fs);
                }
            }
            if(newfileName != null)
            {
                string deletepath = Path.Combine(_env.WebRootPath, "assets", "uploadimg", existhero.Image);
                if(System.IO.File.Exists(deletepath))
                {
                    System.IO.File.Delete(deletepath);
                }
                existhero.Image = newfileName;
            }
            existhero.UpTitle = hero.UpTitle;
            existhero.Title1 = hero.Title1;
            existhero.Title2 = hero.Title2;
            existhero.MenuDesc = hero.MenuDesc;
            existhero.Description = hero.Description;
            existhero.DownTitle = hero.DownTitle;
            existhero.IsDeleted = hero.IsDeleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        // GET: HeroController/Delete/5
        public ActionResult Delete(int id)
        {
            Hero hero = _context.Heroes.Find(id);
            if (hero is null) return RedirectToAction("Index", "404");
            if(hero.IsDeleted==false)
            {
                hero.IsDeleted = true;
            }
            hero.IsDeleted = false;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // POST: HeroController/Delete/5
        
        public ActionResult PermaDelete(int id)
        {
            Hero hero = _context.Heroes.Find(id);
            if (hero is null) return RedirectToAction("Index", "404");
            _context.Heroes.Remove(hero);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
