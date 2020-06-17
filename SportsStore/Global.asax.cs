using SportsStore.App_Start;
using System;
using System.Web.Routing;

namespace SportsStore
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // The static Routes property is a RouteCollection instance needed to perform the configuration.
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}