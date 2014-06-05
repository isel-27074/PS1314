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

        public ActionResult BadRequest()
        {
            return View();
        }

        public ActionResult Forbidden()
        {
            return View();
        }

        public ActionResult MethodNotAllowed()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}