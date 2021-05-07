using DXWebApplication1.Controllers;
using DXWebApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private ApplicationUser oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (ApplicationUser)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is AccountController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Account/SignIn");
                    }



                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Account/SignIn");
            }

        }

    }
}