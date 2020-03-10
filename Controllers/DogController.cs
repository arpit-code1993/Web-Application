using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment_4.Models;
using Newtonsoft.Json;

using Assignment_4.APIHandlerManager;

namespace Assignment_4.Controllers
{
    public class DogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult Dogdata()
        {
            APIHandler1 webHandler = new APIHandler1();
            List<Result> viewdogssdata = webHandler.GetData();

            return View(viewdogssdata);
        }
       
    }
}
