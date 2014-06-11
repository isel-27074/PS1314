using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RawERD
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            HttpException httpException = exception as HttpException;
            Response.Clear();

            if (httpException != null)
            {
                string action;

                switch (httpException.GetHttpCode())
                {
                    case 400:
                        action = "BadRequest";
                        break;
                    case 401:
                        action = "Unauthorized";
                        break;
                    case 403:
                        action = "Forbidden";
                        break;
                    case 404:
                        action = "NotFound";
                        break;
                    case 405:
                        action = "MethodNotAllowed";
                        break;
                    case 500:
                        action = "ServerError";
                        break;
                    default:
                        action = "UnknownError";
                        break;
                }
                Response.Redirect(String.Format("~/Error/{0}", action));
            }
            // clear error on server
            Server.ClearError();
        }
    }
}
