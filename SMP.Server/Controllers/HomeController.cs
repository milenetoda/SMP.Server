using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SMP.Server.App_Start;

namespace SMP.Server.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("processos", "admin");
            }

            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string usuario, string senha, string ReturnUrl)
        {
            if (FormsAuthentication.Authenticate(usuario, senha))
            {
                FormsAuthentication.SetAuthCookie(usuario, false);

                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("processos", "admin");
                }
            }
            else
            {
                ModelState.AddModelError("_", "Usuário e/ou senha incorretos");
                return RedirectToAction("index", "home");
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }
    }
}
