using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using WebApiContrib.Formatting.Jsonp;

namespace Vinyl.UI
{
	public static class WebApiConfig
	{
		//Return JSON instead of XML from ASP.NET Web API Service when a request is made from the browser
		public class CustomJsonFormatter : JsonMediaTypeFormatter
		{
			public CustomJsonFormatter()
			{
				this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			}

			public override void SetDefaultContentHeaders(Type type, 
				                                        HttpContentHeaders headers, 
										    MediaTypeHeaderValue mediaType)
			{
				base.SetDefaultContentHeaders(type, headers, mediaType);
				headers.ContentType = new MediaTypeHeaderValue("application/json");
			}
		}

		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			// Configure Web API to use only bearer token authentication.
			//config.SuppressDefaultHostAuthentication();
			//config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

			#region Formatter
			// Json Formatter - CamelCase
			config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
				new CamelCasePropertyNamesContractResolver();

			// If we need to customize more formats activate one of the options below:
			//Return only JSON from ASP.NET Web API Service:
			//config.Formatters.Remove(config.Formatters.XmlFormatter);

			//Return only XML from ASP.NET Web API Service:
			//config.Formatters.Remove(config.Formatters.JsonFormatter);

			//Return JSON instead of XML from ASP.NET Web API Service when a request is made from the browser:
			//First Sollution 
			//config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			//Second Sollution
			//config.Formatters.Add(new CustomJsonFormatter());
			#endregion

			#region DiffDomain
			//JSONP-To allow cross domain ajax calls by enabling JSONP
			//Install-Package WebApiContrib.Formatting.Jsonp
			var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
			config.Formatters.Insert(0, jsonpFormatter);
			#endregion

			#region routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
			    name: "DefaultApi",
			    routeTemplate: "api/{controller}/{id}",
			    defaults: new { id = RouteParameter.Optional }
			);
			#endregion
		}
	}
}
