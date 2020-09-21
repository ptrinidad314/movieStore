using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieStore.Models
{
    public class FilmDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public short? release_year { get; set; }
        public string rating { get; set; }
        public string imgUrl { get; set; }
    }
}
