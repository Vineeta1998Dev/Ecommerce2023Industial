using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewEcommerc
{
    public class Filter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            var activesetion = session["LoginDeatails"];
            if(activesetion==null)
            {
                var url = new UrlHelper(filterContext.RequestContext);
                var loginurl = url.Content("/home/signin");
                filterContext.HttpContext.Response.Redirect(loginurl,true);
            }
        }
    }
}