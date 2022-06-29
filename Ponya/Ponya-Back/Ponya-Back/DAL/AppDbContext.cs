using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ponya_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {              
        }
        public DbSet<Features> Features { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<Proggress> Proggresses { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioDetailImage> PortfolioDetailImages { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
    }
}
