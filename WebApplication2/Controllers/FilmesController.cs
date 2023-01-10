using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FilmesController:Controller
    {
        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(FIlme fIlme)
        {
            if (ModelState.IsValid)
            {

            }
            return View(fIlme);
        }
    }
}
