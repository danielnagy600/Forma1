using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma1WebApp.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }
        [Display(Name = "Csapatnév")]
        public string Name { get; set; }
        [Display(Name = "Alapítás éve")]
        public int YearOfFoundation { get; set; }
        [Display(Name = "Megnyert világbajnokságok száma")]
        public int WonOfChampionship { get; set; }
        [Display(Name = "Nevezési díj megléte")]
        public bool IsPaid { get; set; }
    }
}
