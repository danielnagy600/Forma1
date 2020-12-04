using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1WebApp.Data.Entities
{
    public class StoreUser : IdentityUser
    {
        public new string UserName { get; set; }
    }
}
