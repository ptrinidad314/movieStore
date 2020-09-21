using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movieStore.Models;
using movieStore.SakilaDB;
using movieStore.Services;

namespace movieStore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        const int FILMS_PER_PAGE = 30;

        private IMovieStoreRepository _movieRepository;

        public HomeController(IMovieStoreRepository movieStoreRepository)//ILogger<HomeController> logger)
        {
            //_logger = logger;
            _movieRepository = movieStoreRepository;
        }

        public IActionResult Index()
        {
            //var model = _movieRepository.GetFilms();
            var model = _movieRepository.GetHomeIndexModel(0, FILMS_PER_PAGE);

            return View(model);     
        }

        public IActionResult GoToNextPage(int pageToGoTo)
        {
            var model = _movieRepository.GetHomeIndexModelByPage(pageToGoTo, FILMS_PER_PAGE);//GetHomeIndexModel(0, 30);

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Index(FilmDTO filmDTO) 
        {
            Startup.Progress = 0;

            for (int i = 1; i <= 100; i++)
            {
                Startup.Progress = i;

                Thread.Sleep(500);
            }


            var model = _movieRepository.GetFilms();

            return View(model);
        }

       


        [HttpPost]
        public void runningTheTest() 
        {
            Startup.Progress = 0;

            for (int i = 1; i <= 100; i++) 
            {
                Startup.Progress = i;

                Thread.Sleep(500);
            }

        }

        [HttpPost]
        public ActionResult Progress() 
        {
            return this.Content(Startup.Progress.ToString());
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
