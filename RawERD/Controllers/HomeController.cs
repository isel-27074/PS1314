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
            return View();
        }

        public ActionResult About()
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
                        Name = "Ricardo",
                        UserName = "Gambas",
                        Password = "123456",
                        ActivationCode = "1234",
                        Active = true,
                        Email = "ricardo.marta@gmail.com"
                    };
                    ricardo.Roles.Add(convidado);
                    ricardo.Roles.Add(utilizador);
                    ricardo.Roles.Add(administrador);

                    User luis = new User
                    {
                        Name = "Luis",
                        UserName = "Bras",
                        Password = "123456",
                        ActivationCode = "1234",
                        Active = true,
                        Email = "lbras@lbras.net"
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

            IList<User> utilizadores;

            using (var dm = new DataModel())
            {
                utilizadores = dm.Users.ToList();
            };

            return View(utilizadores);
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your RawERD team!";

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