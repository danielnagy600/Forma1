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
        [Required(ErrorMessage = "A felhasználónév kitöltése kötelező!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "A jelszó kitöltése kötelező!")]
        public string Password { get; set; }
    }
}
