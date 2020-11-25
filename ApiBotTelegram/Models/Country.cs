using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBotTelegram.Models
{
    public class Country
    {
        //[Column("id")]
        public int Id { get; set; }
        //[Column("country_name")]
        public string CountryName { get; set; }
        //[Column("country_name_search")]
        public string CountryNameSearch { get; set; }
        //[Column("region")]
        public string Region { get; set; }
        //[Column("subrerion")]
        public string Subregion { get; set; }
        //[Column("population")]
        public int Population { get; set; }
        //[Column("last_search")]
        public DateTime LastSearch { get; set; }
    }
}
