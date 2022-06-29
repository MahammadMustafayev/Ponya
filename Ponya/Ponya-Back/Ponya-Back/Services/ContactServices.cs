using Ponya_Back.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Services
{
    public class ContactServices
    {
        private readonly AppDbContext _context;

        public ContactServices(AppDbContext context)
        {
            _context = context;
        }
        public Dictionary<string,string> GetSettings()
        {
            return _context.Settings.ToDictionary(c => c.Key, c => c.Value);
        }
    }
}
