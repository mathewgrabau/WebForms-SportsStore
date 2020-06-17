﻿using System.Web.Routing;

namespace SportsStore.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // This is a composable route
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listing.aspx");

            // Defining the new routing scheme.
            routes.MapPageRoute(null, "", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Listing.aspx");
        }
    }
}