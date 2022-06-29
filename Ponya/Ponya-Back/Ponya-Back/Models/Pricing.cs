using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Models
{
    public class Pricing
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public double CostPrice { get; set; }
        public double SellPrice { get; set; }
        public double? DiscountPrice { get; set; }
        public int StockCount { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeleted { get; set; }
    }
}
