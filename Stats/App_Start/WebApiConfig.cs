﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Stats
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // custom route
            config.Routes.MapHttpRoute(
                name: "GameEvent",
                routeTemplate: "api/game/events",
                defaults: new { controller = "game", action = "CreateEvent" }
            );
        }
    }
}
