using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RawERD.Data;

namespace RawERD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            #region using-add-data
            using (var dm = new DataModel())
            {
                if (!dm.Roles.Any() && !dm.Users.Any())
                {
                    Role convidado = new Role
                    {
                        name = "Convidado",
                        active = true
                    },
                    utilizador = new Role
                    {
                        name = "Utilizador",
                        active = true
                    },
                    administrador = new Role
                    {
                        name = "Administrador",
                        active = true
                    };

                    User ricardo = new User
                    {
                        name = "Ricardo",
                        username = "Gambas",
                        password = "1234",
                        activationCode = "1234",
                        active = true,
                        email = "ricardo.marta@gmail.com"
                    };
                    ricardo.Roles.Add(convidado);
                    ricardo.Roles.Add(utilizador);
                    ricardo.Roles.Add(administrador);

                    User luis = new User
                    {
                        name = "Luis",
                        username = "Bras",
                        password = "1234",
                        activationCode = "1234",
                        active = true,
                        email = "lbras@lbras.net"
                    };
                    luis.Roles.Add(convidado);
                    luis.Roles.Add(utilizador);
                    luis.Roles.Add(administrador);

                    dm.Roles.Add(convidado);
                    dm.Roles.Add(utilizador);
                    dm.Roles.Add(administrador);
                    dm.Users.Add(ricardo);
                    dm.Users.Add(luis);
                };
                dm.SaveChanges();
            };
            #endregion using-add-data

            ViewBag.Message = "Welcome to RawERD Project!";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "RawERD database users:";

            IList<User> utilizadores;

            using (var dm = new DataModel())
            {
                utilizadores = dm.Users.ToList();
            };

            return View(utilizadores);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your RawERD team!";

            return View();
        }

        public ActionResult AccountDisabled()
        {
            return View();
        }

        public ActionResult AccountRemoved()
        {
            return View();
        }
    }
}