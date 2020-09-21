using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieStore.Models
{
    public class HomeIndexDTO
    {
        public List<FilmDTO> FilmsInRange{ get; set; }
        public int TotalFilmCount { get; set; }
        public int FilmListStartIndex { get; set; }
        public int FilmsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumberOfPages { get; set; }
    }
}
