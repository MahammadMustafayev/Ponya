using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [MaxLength(255),Required]
        public string FirstName { get; set; }
        [MaxLength(255),Required]
        public string LastName { get; set; }
        [MaxLength(350)]
        public string EmailAddress { get; set; }
        [MaxLength(255)]
        public string Subject { get; set; }
        public string Comments { get; set; }
        public bool IsDeleted { get; set; }
    }
}
