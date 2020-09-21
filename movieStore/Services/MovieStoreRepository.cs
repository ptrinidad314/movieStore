using movieStore.Models;
using movieStore.SakilaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieStore.Services
{
    public class MovieStoreRepository : IMovieStoreRepository
    {
        List<FilmDTO> IMovieStoreRepository.GetFilms()
        {
            var rand = new Random();
            //"~/img/pic1.jpg"

            using (var db = new sakilaContext())
            {
                var films = (from row in db.Film
                             select new FilmDTO { 
                                title = row.Title,
                                description = row.Description,
                                release_year = row.ReleaseYear,
                                rating = row.Rating,
                                imgUrl = "/img/pic" + rand.Next(1,6).ToString() + ".jpg"
                             }).ToList();

                return films;
            }
        }

        public HomeIndexDTO GetHomeIndexModel(int filmListStartIndex, int filmsPerPage) 
        {
            var rand = new Random();

            using (var db = new sakilaContext()) 
            {
                HomeIndexDTO hiDTO = new HomeIndexDTO();

                var films = (from row in db.Film
                             select new FilmDTO
                             {
                                 title = row.Title,
                                 description = row.Description,
                                 release_year = row.ReleaseYear,
                                 rating = row.Rating,
                                 imgUrl = "/img/pic" + rand.Next(1, 6).ToString() + ".jpg"
                             }).ToList().GetRange(filmListStartIndex, filmsPerPage);



                hiDTO.FilmsInRange = films;
                hiDTO.FilmListStartIndex = filmListStartIndex;
                hiDTO.FilmsPerPage = filmsPerPage;
                hiDTO.TotalFilmCount = db.Film.Count();
                hiDTO.TotalNumberOfPages = (int)Math.Ceiling((double)(hiDTO.TotalFilmCount / hiDTO.FilmsPerPage));
                hiDTO.CurrentPage = GetCurrentPage(hiDTO.TotalFilmCount, hiDTO.FilmsPerPage, filmListStartIndex + 1);

                return hiDTO;
            }
            
        }

        public HomeIndexDTO GetHomeIndexModelByPage(int currentPage, int filmsPerPage) 
        {
            var rand = new Random();

            using (var db = new sakilaContext()) 
            {
                int filmStartIndex = GetCurrentIndexForPage(currentPage, filmsPerPage);

                HomeIndexDTO hiDTO = new HomeIndexDTO();

                var films = (from row in db.Film
                             select new FilmDTO
                             {
                                 title = row.Title,
                                 description = row.Description,
                                 release_year = row.ReleaseYear,
                                 rating = row.Rating,
                                 imgUrl = "/img/pic" + rand.Next(1, 6).ToString() + ".jpg"
                             }).ToList().GetRange(filmStartIndex, filmsPerPage);


                hiDTO.FilmsInRange = films;
                hiDTO.FilmListStartIndex = filmStartIndex;
                hiDTO.FilmsPerPage = filmsPerPage;
                hiDTO.TotalFilmCount = db.Film.Count();
                hiDTO.TotalNumberOfPages = (int)Math.Ceiling((double)(hiDTO.TotalFilmCount/hiDTO.FilmsPerPage));
                hiDTO.CurrentPage = currentPage; //GetCurrentPage(hiDTO.TotalFilmCount, hiDTO.FilmsPerPage, filmListStartIndex + 1);

                return hiDTO;
            }
        }

        private int GetCurrentPage(int totalPages, int itemsPerPage, int currentIdx) 
        {
            for (int i = 1; i < totalPages / itemsPerPage; i++) 
            {
                if ((itemsPerPage * i) > currentIdx) 
                {
                    return i;
                }
            }

            return 0;
        }

        private int GetCurrentIndexForPage(int currentPage,  int itemsPerPage) 
        {
            return (itemsPerPage * (currentPage - 1));
        }
    }
}
