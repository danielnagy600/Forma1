using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma1WebApp.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public int Username { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        public int MyProperty { get; set; }
    }
}
