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
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Aboutus()
        {
            ViewData["Message"] = "Application description page.";
            return View();
        }
        public IActionResult Homepage()
        {
            return View();
        }

        public IActionResult Catdata()
        {
            APIHandler webHandler = new APIHandler();
            List<Result> viewcatsdata = webHandler.GetData();

            return View(viewcatsdata);
        }

        //public IActionResult Catdrugs()
        //{
        //    APIHandler webHandler = new APIHandler();
        //    List<Result> viewcatdrugs = webHandler.GetData();

        //    return View(viewcatdrugs);
        //}

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult CatDrugsChart()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Spinosad", 8));
            dataPoints.Add(new DataPoint("Pimobendan", 1));
            dataPoints.Add(new DataPoint("Emodepside, Praziquantel", 24));
            dataPoints.Add(new DataPoint("Dexmedetomidine Hydrochloride", 8));
            dataPoints.Add(new DataPoint("Fluoxetine", 1));
            dataPoints.Add(new DataPoint("Imidacloprid, Moxidectin", 49));
            dataPoints.Add(new DataPoint("Ivermectin, Pyrantel Pamoate, Praziquantel", 1));
            dataPoints.Add(new DataPoint("Maropitant", 8));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
        public IActionResult Dogdata()
        {
            APIHandler1 webHandler = new APIHandler1();
            List<Result> viewdogssdata = webHandler.GetData();

            return View(viewdogssdata);
        }


        public ActionResult DogDrugsChart()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Spinosad",11));
            dataPoints.Add(new DataPoint("Selamectin",20));
            dataPoints.Add(new DataPoint("Moxidectin",35));
            dataPoints.Add(new DataPoint("Praziquantel",1));
            dataPoints.Add(new DataPoint("Pimobendan",2));
            dataPoints.Add(new DataPoint("Nitenpyram",8));
            dataPoints.Add(new DataPoint("Milbemycin",1));
            dataPoints.Add(new DataPoint("Clotrimazole, Gentamicin Sulfate",1));
           

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
    }
}
