using FileSharing.AdvertisingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileSharing.Controllers
{
    public class AdvertisingController : Controller
    {

        //GET: Spam
        public ActionResult Index()
        {
            return PartialView();
        }

        public FileContentResult GetImage()
        {
            SpamServiceClient spamClient = new SpamServiceClient();

            var spam = spamClient.GetAdvertising();

            if(spam != null)
            {
                return File(spam.Image, spam.TypeImage);
            }

            return null;
        }
    }
}