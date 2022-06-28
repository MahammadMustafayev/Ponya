using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Models
{
    public class PortfolioCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public List<Portfolio> Portfolios { get; set; }
    }
}
