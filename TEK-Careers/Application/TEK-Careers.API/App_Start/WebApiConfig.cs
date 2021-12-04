using System.Web.Http;

namespace TEK_Careers.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/v1/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
            name: "ApiCntrlAction",
            routeTemplate: "api/v1/{controller}/{action}"
            );
        }
    }
}