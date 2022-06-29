using Ponya_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.ViewModel.ServiceViewModel
{
    public class ServiceVM
    {
        public List<Hero> Heroes { get; set; }
        public List<Features> Features { get; set; }
        public List<PortfolioDetailImage> PortfolioDetailImages { get; set; }
        
    }
}
