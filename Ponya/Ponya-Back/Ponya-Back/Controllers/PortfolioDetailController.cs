using Microsoft.AspNetCore.Mvc;
using Ponya_Back.DAL;
using Ponya_Back.ViewModel.PortfolioDetailViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Controllers
{

    public class PortfolioDetailController : Controller
    {
        private readonly AppDbContext _context;

        public PortfolioDetailController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            PortfolioDetailVM portfolioDetailVM = new PortfolioDetailVM
            {
                Features = _context.Features.Where(x=>x.IsDeleted==false).Take(4).ToList(),
                PortfolioDetailImages=_context.PortfolioDetailImages.Where(x=>x.IsDeleted==false).Take(4).ToList()
            };
            return View(portfolioDetailVM);
        }
    }
}
