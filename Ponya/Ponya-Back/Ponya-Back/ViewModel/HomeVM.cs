using Ponya_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.ViewModel
{
    public class HomeVM
    {
        public List<Features> Features { get; set; }
        public List<Companies> Companies { get; set; }
        public List<Hero> Heroes { get; set; }
    }
}
