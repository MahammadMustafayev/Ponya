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
    public class CompanyController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public CompanyController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        // GET: CompanyController
        public ActionResult Index()
        {
            return View(_context.Companies.ToList());
        }

        

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Companies companies )
        {
            if (!ModelState.IsValid) return BadRequest();
            if (companies.Photo != null)
            {
                if (companies.Photo.ContentType != "image/jpg"
                    && companies.Photo.ContentType != "image/png"
                    && companies.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png and .webp");
                    return View(companies);
                }
                if (companies.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(companies);
                }
                string fileName = companies.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newFileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    companies.Photo.CopyTo(stream);
                }
                companies.Image = newFileName;
                _context.Companies.Add(companies);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)
        {
            Companies companies = _context.Companies.FirstOrDefault(x => x.Id == id);
            if (companies is null) return RedirectToAction("Index", "404");
            return View(companies);
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Companies companies)
        {
            Companies existcompanies = _context.Companies.FirstOrDefault(x => x.Id == companies.Id);
            if (existcompanies == null) return RedirectToAction("Index", "404");
            string newfileName = null;
            if (existcompanies.Photo != null)
            {
                if (companies.Photo.ContentType != "image/jpeg"
                    && companies.Photo.ContentType != "image/png"
                    && companies.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png");
                    return View(companies);
                }
                if (companies.Photo.Length / 1024 > 2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(companies);
                }
                string fileName = companies.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                newfileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newfileName);
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    companies.Photo.CopyTo(fs);
                }
            }
            if (newfileName != null)
            {
                string deletepath = Path.Combine(_env.WebRootPath, "assets", "uploadimg", existcompanies.Image);
                if (System.IO.File.Exists(deletepath))
                {
                    System.IO.File.Delete(deletepath);
                }
                existcompanies.Image = newfileName;
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: CompanyController/Delete/5
        
        public ActionResult Delete(int id)
        {
            Companies companies = _context.Companies.Find(id);
            if (companies is null) return RedirectToAction("Index", "404");
            if(companies.IsDeleted==false)
            {
                companies.IsDeleted = true;
            }
            companies.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: CompanyController/Delete/5
        
        public ActionResult PermaDelete(int id)
        {
            Companies companies = _context.Companies.Find(id);
            if (companies is null) return RedirectToAction("Index", "404");
            _context.Companies.Remove(companies);
            return RedirectToAction(nameof(Index));

        }
    }
}
