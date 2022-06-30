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
    public class PortfolioCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public PortfolioCategoryController(AppDbContext context)
        {
            _context = context;
        }
        // GET: PortfolioCategoryController
        public ActionResult Index()
        {
            return View(_context.PortfolioCategories.ToList());
        }

       

        // GET: PortfolioCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortfolioCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PortfolioCategory portfolioCategory)
        {
            if (portfolioCategory == null) return RedirectToAction("Index", "404");
            _context.PortfolioCategories.Add(portfolioCategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: PortfolioCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            PortfolioCategory portfolioCategory = _context.PortfolioCategories.FirstOrDefault(c => c.Id == id);
            if(portfolioCategory is null) return RedirectToAction("Index", "404");
            return View(portfolioCategory);
        }

        // POST: PortfolioCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( PortfolioCategory portfolioCategory)
        {
            PortfolioCategory existportcategory = _context.PortfolioCategories.FirstOrDefault(x => x.Id == portfolioCategory.Id);
            if (existportcategory == null) return RedirectToAction("Index", "404");
            existportcategory.CategoryName = portfolioCategory.CategoryName;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: PortfolioCategoryController/Delete/5
       
        public ActionResult Delete(int id)
        {
            PortfolioCategory portfolioCategory = _context.PortfolioCategories.Find(id);
            if (portfolioCategory is null) return RedirectToAction("Index", "404");
            if (portfolioCategory.IsDeleted == false) portfolioCategory.IsDeleted = true;
            portfolioCategory.IsDeleted = false;
            _context.PortfolioCategories.Remove(portfolioCategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: PortfolioCategoryController/Delete/5
        
        public ActionResult PermaDelete(int id)
        {
            PortfolioCategory portfolioCategory = _context.PortfolioCategories.Find(id);
            if (portfolioCategory is null) return RedirectToAction("Index", "404");
            _context.PortfolioCategories.Remove(portfolioCategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
