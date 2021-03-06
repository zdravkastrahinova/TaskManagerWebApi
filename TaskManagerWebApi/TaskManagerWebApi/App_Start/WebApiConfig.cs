﻿using Newtonsoft.Json;
using System.Web.Http;

namespace TaskManagerWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API format
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Enable Cross-Origin Resource Sharing
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{optionalController}",
                defaults: new { id = RouteParameter.Optional, optionalController = RouteParameter.Optional }
            );
        }
    }
}
