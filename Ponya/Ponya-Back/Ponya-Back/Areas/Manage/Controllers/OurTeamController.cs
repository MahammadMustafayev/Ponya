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
    public class OurTeamController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public OurTeamController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        // GET: OurTeamController
        public ActionResult Index()
        {
            return View(_context.OurTeams.ToList());
        }

        

        // GET: OurTeamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OurTeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OurTeam ourTeam)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (ourTeam.Photo != null)
            {
                if (ourTeam.Photo.ContentType != "image/jpg"
                    && ourTeam.Photo.ContentType != "image/png"
                    && ourTeam.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png and .webp");
                    return View(ourTeam);
                }
                if (ourTeam.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(ourTeam);
                }
                string fileName = ourTeam.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newFileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    ourTeam.Photo.CopyTo(stream);
                }
                ourTeam.Image = newFileName;
                _context.OurTeams.Add(ourTeam);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: OurTeamController/Edit/5
        public ActionResult Edit(int id)
        {
            OurTeam ourTeam = _context.OurTeams.FirstOrDefault(x => x.Id == id);
            if (ourTeam is null) return RedirectToAction("Index", "404");
            return View(ourTeam);
        }

        // POST: OurTeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OurTeam ourTeam  )
        {
            OurTeam existteam = _context.OurTeams.FirstOrDefault(x => x.Id == ourTeam.Id);
            if (existteam == null) return RedirectToAction("Index", "404");
            string newfileName = null;
            if (existteam.Photo != null)
            {
                if (ourTeam.Photo.ContentType != "image/jpeg"
                    && ourTeam.Photo.ContentType != "image/png"
                    && ourTeam.Photo.ContentType != "image/webp")
                {
                    ModelState.AddModelError("Photo", "Image can be only .jpeg or .png");
                    return View(ourTeam);
                }
                if (ourTeam.Photo.Length / 1024 > 2000)
                {
                    ModelState.AddModelError("Photo", "Image  size must be lower than 2mb ");
                    return View(ourTeam);
                }
                string fileName = ourTeam.Photo.FileName;
                if (fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }
                newfileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "uploadimg", newfileName);
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    ourTeam.Photo.CopyTo(fs);
                }
            }
            if (newfileName != null)
            {
                string deletepath = Path.Combine(_env.WebRootPath, "assets", "uploadimg", existteam.Image);
                if (System.IO.File.Exists(deletepath))
                {
                    System.IO.File.Delete(deletepath);
                }
                existteam.Image = newfileName;
            }
            existteam.FullName = ourTeam.FullName;
            existteam.Position = ourTeam.Position;
            existteam.RankNumber = ourTeam.RankNumber;
            existteam.BriefInformation = ourTeam.BriefInformation;
            existteam.IsDeleted = ourTeam.IsDeleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: OurTeamController/Delete/5
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            OurTeam ourTeam = _context.OurTeams.Find(id);
            if (ourTeam is null) return RedirectToAction("Index", "404");
            if(ourTeam.IsDeleted==false)
            {
                ourTeam.IsDeleted = true;
            }
            ourTeam.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: OurTeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PermaDelete(int id)
        {
            OurTeam ourTeam = _context.OurTeams.Find(id);
            if (ourTeam is null) return RedirectToAction("Index", "404");
            _context.OurTeams.Remove(ourTeam);
            return RedirectToAction(nameof(Index));
        }
    }
}
