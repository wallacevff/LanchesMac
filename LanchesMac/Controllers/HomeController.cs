using LanchesMac.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LanchesMac.Repositories;
using LanchesMac.Models.ViewModels;

namespace LanchesMac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel(_lancheRepository.LanchesPreferidos);
            return View(homeViewModel);
        }

        public ViewResult AccessDenied()
        {
            return View();
        }

    }
}
