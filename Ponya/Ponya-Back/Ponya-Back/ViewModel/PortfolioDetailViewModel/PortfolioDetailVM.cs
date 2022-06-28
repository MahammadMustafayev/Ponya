using Ponya_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.ViewModel.PortfolioDetailViewModel
{
    public class PortfolioDetailVM
    {
        public List<PortfolioDetailImage> PortfolioDetailImages { get; set; }
        public List<Features> Features { get; set; }
    }
}
