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
    public class PortfolioController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public PortfolioController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        // GET: PortfolioController
        public ActionResult Index()
        {
            return View(_context.Portfolios.Include(x=>x.PortfolioCategory).ToList());
        }

        

        // GET: PortfolioController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _context.PortfolioCategories.Where(x => x.IsDeleted == false).ToList();
            return View();
        }

        // POST: PortfolioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Portfolio portfolio)
        {
            ViewBag.Categories = _context.PortfolioCategories.Where(x => x.IsDeleted == false).ToList();
            if (!ModelState.IsValid) return BadRequest();
            if(portfolio.Photo != null)
            {
                if(portfolio.Photo.ContentType != "image/jpg"
                    && portfolio.Photo.ContentType != "image/png"
                    && portfolio.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png and .webp");
                    return View(portfolio);
                }
                if(portfolio.Photo.Length /1024 >2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(portfolio);
                }
                string fileName = portfolio.Photo.FileName;
                if(fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newFileName);
                using(FileStream stream = new FileStream(path,FileMode.Create))
                {
                    portfolio.Photo.CopyTo(stream);
                }
                portfolio.Image = newFileName;
                _context.Portfolios.Add(portfolio);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: PortfolioController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = _context.PortfolioCategories.Where(x => x.IsDeleted == false).ToList();
            Portfolio portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio == null) return RedirectToAction("Index", "404");

            return View(portfolio);
        }

        // POST: PortfolioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Portfolio portfolio)
        {
            ViewBag.Categories = _context.PortfolioCategories.Where(x => x.IsDeleted == false).ToList();
            Portfolio existportfolio = _context.Portfolios.FirstOrDefault(x => x.Id == portfolio.Id);
            if (existportfolio == null) return RedirectToAction("Index", "404");
            string newfileName = null;
            if (existportfolio.Photo != null)
            {
                if (portfolio.Photo.ContentType != "image/jpeg"
                    && portfolio.Photo.ContentType != "image/png"
                    && portfolio.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png");
                    return View(portfolio);
                }
                if (portfolio.Photo.Length / 1024 > 2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(portfolio);
                }
                string fileName = portfolio.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                newfileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newfileName);
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    portfolio.Photo.CopyTo(fs);
                }
            }
            if (newfileName != null)
            {
                string deletepath = Path.Combine(_env.WebRootPath, "assets", "uploadimg", existportfolio.Image);
                if (System.IO.File.Exists(deletepath))
                {
                    System.IO.File.Delete(deletepath);
                }
                existportfolio.Image = newfileName;
            }
            existportfolio.CategoryId = portfolio.CategoryId;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: PortfolioController/Delete/5
        
        public ActionResult Delete(int id)
        {
            Portfolio portfolio = _context.Portfolios.Find(id);
            if (portfolio == null) return RedirectToAction("Index", "404");
            if (portfolio.IsDeleted == false) portfolio.IsDeleted = true;
            portfolio.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: PortfolioController/Delete/5
       
        public ActionResult PermaDelete(int id)
        {
            Portfolio portfolio = _context.Portfolios.Find(id);
            if (portfolio == null) return RedirectToAction("Index", "404");
            _context.Portfolios.Remove(portfolio);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
