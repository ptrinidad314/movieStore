using movieStore.Models;
using movieStore.SakilaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieStore.Services
{
    public interface IMovieStoreRepository
    {
        List<FilmDTO> GetFilms();

        HomeIndexDTO GetHomeIndexModel(int filmListStartIndex, int filmsPerPage);
        HomeIndexDTO GetHomeIndexModelByPage(int currentPage, int filmsPerPage);
    }
}
