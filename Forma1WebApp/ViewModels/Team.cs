using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma1WebApp.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int YearOfFoundation { get; set; }
        public int WonOfChampionship { get; set; }
        public bool IsPaid { get; set; }
    }
}
