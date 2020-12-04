using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1WebApp.Data.Entities
{
    public class StoreUser : IdentityUser
    {
        public string UsernName { get; set; }
    }
}
