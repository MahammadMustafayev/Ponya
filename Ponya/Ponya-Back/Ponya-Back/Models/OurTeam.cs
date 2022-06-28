using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Models
{
    public class OurTeam
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string FullName { get; set; }
        public string Position { get; set; }
        [MaxLength(50)]
        public string BriefInformation { get; set; }
        [MaxLength(5)]
        public int RankNumber { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}
