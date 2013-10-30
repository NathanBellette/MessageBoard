using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace MessageBoard
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();

            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

		    config.Routes.MapHttpRoute(
                    name: "RepliesRoute",
                    routeTemplate: "api/topics/{topicid}/replies/{id}",
                    defaults: new { controller = "topics", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/topics/{id}",
                defaults: new { controller = "topics", id = RouteParameter.Optional }
            );
        }
    }
}
