using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ponya_Back.DAL;
using Ponya_Back.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Features = await _context.Features.Where(x => x.IsDeleted == false).Take(3).ToListAsync(),
                Companies = await _context.Companies.Where(x => x.IsDeleted == false).Take(5).ToListAsync(),
                Heroes = await _context.Heroes.Where(x => x.IsDeleted == false).Take(1).ToListAsync()
            };
            return View(homeVM);
        }
    }
}
