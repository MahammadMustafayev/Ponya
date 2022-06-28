using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public PortfolioCategory PortfolioCategory { get; set; }
        public bool IsDeleted { get; set; }
    }
}
