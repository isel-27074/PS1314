using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RawERD.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Unauthorized");
        }

        public ActionResult BadRequest() //400
        {
            return View();
        }

        public ActionResult Forbidden() //403
        {
            return View();
        }

        public ActionResult MethodNotAllowed() //405
        {
            return View();
        }

        public ActionResult NotFound() //404
        {
            return View();
        }

        public ActionResult Unauthorized() //401
        {
            return View();
        }

        public ActionResult ServerError() //500
        {
            return View();
        }

        public ActionResult UnknownError()
        {
            return View();
        }
    }
}