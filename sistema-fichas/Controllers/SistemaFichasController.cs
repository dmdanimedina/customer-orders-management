using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebMatrix.WebData;



namespace sistema_fichas.Controllers
{
    public class SistemaFichasController : Controller
    {
        protected static bool status_error = false;
        protected static bool status_success = true;
        protected static String mensaje_error = "Ocurrio un problema al intentar {0}, por favor intente de nuevo.";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            try
            {
                    Permisos(Request.Url.LocalPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        

        protected void Permisos(string returnPath){
            if (!WebSecurity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login?returnUrl=" + returnPath);
            }
        }
        
        protected string RenderPartialViewToString()
        {
            return RenderPartialViewToString(null, null);
        }

        protected string RenderPartialViewToString(string viewName)
        {
            return RenderPartialViewToString(viewName, null);
        }

        protected string RenderPartialViewToString(object model)
        {
            return RenderPartialViewToString(null, model);
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

    }
}
