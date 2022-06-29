using Ponya_Back.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Services
{
    public class SocialServices
    {
        private readonly AppDbContext _context;

        public SocialServices(AppDbContext context)
        {
            _context = context;
        }
        public Dictionary<string,string> GetSettings()
        {
            return _context.Settings.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
