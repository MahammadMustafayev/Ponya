using Microsoft.AspNetCore.Mvc;
using Ponya_Back.DAL;
using Ponya_Back.ViewModel.ServiceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context )
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ServiceVM serviceVM = new ServiceVM
            {
                Features = _context.Features.Where(x=>x.IsDeleted==false).Take(3).ToList(),
                Heroes = _context.Heroes.Where(x=>x.IsDeleted==false).ToList(),
                PortfolioDetailImages= _context.PortfolioDetailImages.Where(x=>x.IsDeleted==false).Take(4).ToList()
            };
            return View(serviceVM);
        }
    }
}
