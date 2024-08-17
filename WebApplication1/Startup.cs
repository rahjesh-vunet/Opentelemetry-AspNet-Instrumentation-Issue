using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Xml.Linq;


[assembly: OwinStartup(typeof(HeaderReproductionTest.Startup))]

namespace HeaderReproductionTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Add custom middleware to reproduce the error
            app.Use<ClaimsTransformationMiddleware>();


            // Set up Web API configuration
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

          

           
            // Add Web API to the OWIN pipeline
            app.UseWebApi(config);
        }
    }

    public class ClaimsTransformationMiddleware : OwinMiddleware
    {
        public ClaimsTransformationMiddleware(OwinMiddleware next) : base(next) { }

        public override async Task Invoke(IOwinContext context)
        {

            Console.WriteLine("Middleware Invoked...");
            System.Diagnostics.Debug.WriteLine("Middleware Invoked...");


            // Attempt to set a header (which may cause the error)
            context.Request.Headers["Custom-Header"] = "MyHeaderValue";

            // Continue to the next middleware
            await Next.Invoke(context);

            Console.WriteLine($"Finished processing request: {context.Request.Path}");
            System.Diagnostics.Debug.WriteLine($"Finished processing request: {context.Request.Path}");

            String key = "key";
            String value = "value";
            String[] values = { "ss" };

            //System.Collections.Specialized.NameValueCollection.Set(String name, String value);
            //System.Web.HttpHeaderCollection.SetHeader(String name, String value, Boolean replace);
            //Microsoft.Owin.Host.SystemWeb.CallHeaders.AspNetRequestHeaders.Set(key, values);
            //Microsoft.Owin.HeaderDictionary.set_Item(key, value);
            ////LR.Brix.Security.ResourceAuthorization.OwinApps.ClaimsTransformationMiddleware.< Invoke > d__4.MoveNext()

        }
    }
}
