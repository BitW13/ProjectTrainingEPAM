using FileSharing.Entities.Logging;
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
            ViewBag.Message = "О сайте.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";

            return View();
        }
    }
}