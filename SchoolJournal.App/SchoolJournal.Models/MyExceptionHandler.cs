using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolJournal.Models
{
    public class MyExceptionHandler:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            if (exceptionContext.ExceptionHandled || exceptionContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
            string actionName = exceptionContext.RouteData.Values["action"].ToString();
            string controllerName = exceptionContext.RouteData.Values["controller"].ToString();

            Exception e = exceptionContext.Exception;
            //Exception custException = new Exception("There is some error.");
            
            var model = new HandleErrorInfo(e, controllerName, actionName);

            exceptionContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Error",
                ViewData = new ViewDataDictionary(model),
                TempData = exceptionContext.Controller.TempData
            };
            exceptionContext.ExceptionHandled = true;
        }
    }
}
