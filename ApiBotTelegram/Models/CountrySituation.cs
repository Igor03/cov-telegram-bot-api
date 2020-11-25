using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBotTelegram.Models
{
    public class CountrySituation
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public int ActiveCases { get; set; }
        public int RecoveredCases { get; set; }
        public int FatalCases { get; set; }
        public DateTime SearchDate { get; set; }
}
}
