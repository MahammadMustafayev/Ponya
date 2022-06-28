using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ponya_Back.DAL;
using Ponya_Back.ViewModel.PortfolioViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;

        public PortfolioController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            PortfolioVM portfolio = new PortfolioVM
            {
                Portfolios= _context.Portfolios.Include(x=>x.PortfolioCategory).Where(x=>x.IsDeleted==false).ToList()
            };
            return View(portfolio);
        }
    }
}
