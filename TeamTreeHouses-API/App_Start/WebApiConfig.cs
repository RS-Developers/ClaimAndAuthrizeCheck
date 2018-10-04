using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
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
            var lJsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            if (lJsonFormatter != null)
            {
                //lJsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat; // return date like: Date=/Date(1538553687358+0330)/
                //lJsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat; // return date like: Date=2018-10-03T11:30:56.8580569+03:30
                // Default: Date=2018-10-03T11:30:29.6790092+03:30
            }//end if
        }
    }
}
