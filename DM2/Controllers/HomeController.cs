using DM2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DM2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //var logged = User.Identity.IsAuthenticated;
            //if(logged)
            //{

            //using (ApplicationDbContext db = new ApplicationDbContext())
            //{

            //    var _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            //    var _UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                //Crear Cuentas
                //var user = new ApplicationUser();
                //user.UserName = "Cush";
                //user.Email = "cush@live.com";
                //var resultado = _UserManager.Create(user, "qawsed12");

                //var usuario = db.Users.Select(x => x.Id).FirstOrDefault();

                //var id = User.Identity.GetUserId();


                //Crear un rol
                //var user2 = _roleManager.Create(new IdentityRole("Escritor"));
                //var user2 = _roleManager.Create(new IdentityRole("Admin"));

                //Se agrega el usuario a un rol
                //user2 = _UserManager.AddToRole(usuario, "Admin");

                //Corroborar que el usuario este el rol
                //var userRole = _UserManager.IsInRole(usuario, "Admin");

                //roles de usuario
                //var roles = _UserManager.GetRoles(IdUser);

                //Remover a usuario de Rol
                //user = _UserManager.RemoveFromRole(idUser, "Admin");

                //Borrar rol
                //var rolDelete = _roleManager.FindByeName("Admin");
                //_roleManager.Delete(rolDelete);

                //}
            //}


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}