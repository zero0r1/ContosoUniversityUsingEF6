using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContosoUniversity
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Route data
            //Route data is data that the model binder found in a
            //URL segment specified in the routing table.For example, 
            //the default route specifies controller, action, and id segments:

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //In the following URL, the default route maps Instructor as the controller, 
            //Index as the action and 1 as the id; these are route data values.
            //http://localhost:1230/Instructor/Index/1?courseID=2021
            //"?courseID=2021" is a query string value. 
            //The model binder will also work if you pass the id as a query string value:
            //http://localhost:1230/Instructor/Index?id=1&CourseID=2021
            //The URLs are created by ActionLink statements in the Razor view.In the following code, 
            //the id parameter matches the default route, so id is added to the route data.

            //@Html.ActionLink("Select", "Index", new { id = item.PersonID })

            //In the following code, courseID doesn't match a parameter in the default route, so it's added as a query string.
            //@Html.ActionLink("Select", "Index", new { courseID = item.CourseID })

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
