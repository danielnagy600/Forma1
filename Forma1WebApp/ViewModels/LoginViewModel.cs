using System.ComponentModel.DataAnnotations;

namespace Forma1WebApp.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "A felhasználónév kitöltése kötelező!")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "A jelszó kitöltése kötelező!")]
    public string Password { get; set; } = string.Empty;
}
