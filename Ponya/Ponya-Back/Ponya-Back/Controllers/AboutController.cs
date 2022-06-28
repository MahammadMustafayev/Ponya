using Microsoft.AspNetCore.Mvc;
using Ponya_Back.DAL;
using Ponya_Back.ViewModel.AboutViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM
            {
                AboutUs= _context.AboutUs.Where(x=>x.IsDeleted==false).Take(2).ToList(),
                OurTeams = _context.OurTeams.Where(x=>x.IsDeleted==false).OrderByDescending(x=>x.RankNumber).Take(3).ToList(),
                Proggresses=_context.Proggresses.Where(x=>x.IsDeleted==false).Take(3).ToList()
            };
            return View(aboutVM);
        }
    }
}
