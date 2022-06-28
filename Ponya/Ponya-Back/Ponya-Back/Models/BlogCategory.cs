using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Models
{
    public class BlogCategory
    {
        public int Id { get; set; }
        public string CatogryName { get; set; }
        public bool IsDeleted { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
