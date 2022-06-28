using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ponya_Back.DAL;
using Ponya_Back.ViewModel.BlogViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        // GET: BlogController
        public ActionResult Index()
        {
            BlogVM blogVM = new BlogVM
            {
                Blogs= _context.Blogs.Include(c=>c.BlogCategory).Where(x=>x.IsDeleted==false).Take(6).ToList()
            };
            return View(blogVM);
        }

        
    }
}
