using System.Web.Http;
using System.Web.Routing;

namespace UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();


            RouteTable.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}/{action}/{id}",
                  defaults: new { action = System.Web.Http.RouteParameter.Optional, id = System.Web.Http.RouteParameter.Optional }
                  );//.RouteHandler = new MyRouteHandler();

            RouteTable.Routes.MapHttpRoute(
               name: "DefaultApi2",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = System.Web.Http.RouteParameter.Optional }
               );//.RouteHandler = new MyRouteHandler();

        }
    }
}
