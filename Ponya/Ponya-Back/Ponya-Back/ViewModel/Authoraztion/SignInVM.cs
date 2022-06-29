using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.ViewModel.Authoraztion
{
    public class SignInVM
    {
        [Required]
        public string UsernameorEmail { get; set; }
        [DataType(DataType.Password),Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
