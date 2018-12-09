using FileSharing.Logging;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileSharing.Controllers
{
    public class HomeController : Controller
    {
        private static IContainer _container = DependencyResolution.IoC.Initialize();
        public ActionResult Index()
        {

            Logger.InitLogger();
            Logger.Log.Info("Главная страница");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Logger.Log.Info("About");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}