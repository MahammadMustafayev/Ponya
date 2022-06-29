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
    public class PricingController : Controller
    {
        private readonly AppDbContext _context;

        public PricingController(AppDbContext context)
        {
            _context = context;
        }
        // GET: PricingController
        public ActionResult Index()
        {
            return View(_context.Pricings.ToList());
        }

        

        // GET: PricingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PricingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pricing pricing)
        {
            if (pricing is null) return BadRequest();
            _context.Pricings.Add(pricing);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: PricingController/Edit/5
        public ActionResult Edit(int id)
        {
            Pricing pricing = _context.Pricings.FirstOrDefault(x => x.Id == id);
            if (pricing == null) return RedirectToAction("Index", "404");
            return View(pricing);
        }

        // POST: PricingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pricing pricing)
        {
            Pricing existprice = _context.Pricings.FirstOrDefault(x => x.Id == pricing.Id);
            if (existprice == null) return RedirectToAction("Index", "404");
            existprice.Title = pricing.Title;
            existprice.SellPrice = pricing.SellPrice;
            existprice.CostPrice = pricing.CostPrice;
            existprice.DiscountPrice = pricing.DiscountPrice;
            existprice.StockCount = pricing.StockCount;
            existprice.IsNew = pricing.IsNew;
            existprice.IsDeleted = pricing.IsDeleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: PricingController/Delete/5
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Pricing pricing = _context.Pricings.Find(id);
            if (pricing is null) return RedirectToAction("Index", "404");
            if (pricing.IsDeleted == false) pricing.IsDeleted = true;
            pricing.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: PricingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PermaDelete(int id)
        {
            Pricing pricing = _context.Pricings.Find(id);
            if (pricing is null) return RedirectToAction("Index", "404");
            _context.Pricings.Remove(pricing);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
