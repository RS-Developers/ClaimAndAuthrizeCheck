using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;

namespace TeamTreeHouses_API
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

            //
#if DEBUG
            foreach (var lFormatting in config.Formatters)
            {
                Debug.WriteLine(lFormatting.GetType());
                foreach (var lMediaType in lFormatting.SupportedMediaTypes)
                    Debug.WriteLine("\t" + lMediaType.MediaType);
            }//end foreach
#endif
            // Json Formatter

        }
    }
}
