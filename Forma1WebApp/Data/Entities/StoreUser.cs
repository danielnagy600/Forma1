using Microsoft.AspNetCore.Identity;

namespace Forma1WebApp.Data.Entities;

public class StoreUser : IdentityUser
{
    public string? UsernName { get; set; }
}
