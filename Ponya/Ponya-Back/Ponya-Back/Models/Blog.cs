using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}
