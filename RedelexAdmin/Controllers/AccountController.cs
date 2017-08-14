using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedelexBLL;

namespace RedelexAdmin.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        //
        // GET: /Account/

        

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");// View();
        }
        [HttpPost]
        public JsonResult ValidateUser(string userid, string password)
        {
            RedelexBLL.Usuario u = new RedelexBLL.Usuario();
            SessionObject _s = new SessionObject();
            
            if (u.Login(userid, password))
            {
                _s.Usuario = u;
                _s.Cuenta = u.Cuenta;

                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            

        }

    }

    public class VerifyUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["UsuarioId"];
            if (user == null) 
                filterContext.Result = new RedirectResult(string.Format(VirtualPathUtility.ToAbsolute("~/Account/Login?targetUrl={0}"), filterContext.HttpContext.Request.Url.AbsolutePath));
        }
    }
    
}
