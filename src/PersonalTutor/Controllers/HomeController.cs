using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using PersonalTutor.ViewModels.Home;

namespace PersonalTutor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }


        public IActionResult Error()
        {
            return View();
        }


        // POST: /Home/Confirmed
        [HttpPost]
        [AllowAnonymous]
        public  IActionResult SendRequest(ForeignerViewModel model)
        {
            return View(model);
        }


    }
}
