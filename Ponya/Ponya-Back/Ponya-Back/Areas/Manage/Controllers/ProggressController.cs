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
    public class ProggressController : Controller
    {
        private readonly AppDbContext _context;

        public ProggressController(AppDbContext context)
        {
            _context = context;
        }
        // GET: ProggressController
        public ActionResult Index()
        {
            return View(_context.Proggresses.ToList());
        }

        

        // GET: ProggressController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProggressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proggress proggress)
        {
            if (proggress is null) return BadRequest();
            _context.Proggresses.Add(proggress);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProggressController/Edit/5
        public ActionResult Edit(int id)
        {
            Proggress proggress = _context.Proggresses.FirstOrDefault(x => x.Id == id);
            if (proggress == null) return RedirectToAction("Index", "404");
            return View(proggress);
        }

        // POST: ProggressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Proggress proggress)
        {
            Proggress existproggress = _context.Proggresses.FirstOrDefault(x => x.Id == proggress.Id);
            if (existproggress is null) return RedirectToAction("Index", "404");
            existproggress.Name = proggress.Name;
            existproggress.Raiting = proggress.Raiting;
            existproggress.IsDeleted = proggress.IsDeleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProggressController/Delete/5
        public ActionResult Delete(int id)
        {
            Proggress proggress = _context.Proggresses.Find(id);
            if (proggress == null) return RedirectToAction("Index", "404");
            if(proggress.IsDeleted==false)
            {
                proggress.IsDeleted = true;
            }
            proggress.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: ProggressController/Delete/5
        
        public ActionResult PermaDelete(int id)
        {
            Proggress proggress = _context.Proggresses.Find(id);
            if (proggress == null) return RedirectToAction("Index", "404");
            _context.Proggresses.Remove(proggress);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
