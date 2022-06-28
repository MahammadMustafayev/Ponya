using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Models
{
    public class Proggress
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Raiting { get; set; }
        public bool IsDeleted { get; set; }
    }
}
