using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;


// What is OWIN? It's basicaly a pipeline between a web request and a server
// OWIN allow us to create components that can execute code while the web request is reaching the server
// It's important to understand that each component can execute code in two specific moments while the request is reaching the server.
// 1. Code can be executed while the request is going from the request raiser to the request handler.
// 2. Code can be executed while the request is going from the request handler to the request raiser.

// First we need to install the nuget package Microsoft.Owin.Host.SystemWeb version 3.0.1
// It will install another dependencies:
// - Owin.1.0.0
// - Microsoft.Owin.3.0.1
// - Microsoft.Owin.Host.SystemWeb.3.0.1

// OWIN uses a class usually known as Startup that will have a static void method named Configuration that receives IAppBuilder parameter
// All OWIN components will be added to the IAppBuilder object

// There are different ways of creating a middleware inside OWIN's pipeline.
// 1. Literal: Creating an implicit delegate inside app.Use method of IAppBuilder object inside Configuration method
// 2. Class: Creating a class that can be specified inside Configuration method to use
// 3. Static class: Creating a static class that will allow us to call the component as a method of IAppBuilder object inside Configuration method

// This line is needed in able to tell OWIN where is the Startup class be to used
// This setting can be set at web.config file too. 

[assembly: OwinStartup(typeof(WebAppProject.Startup))]

namespace WebAppProject
{
    // As you can see, each component written as a class have a private field with the same signature
    // It's recommended to 
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            // Example 1: Literal implementation
            // Use of implicit delegate that is like this:
            // System.Func<Microsoft.Owin.IOwinContext, System.Func<Task>, Task> handler
            app.Use(async (ctx, next) =>
            {

                // Start of code executed from request raiser to request handler
                // Write code inside middleware 
                //await ctx.Response.WriteAsync("<p>On request raiser of literal middleware</p>");
                //Debug.WriteLine("On request raiser of literal middleware");
                // End of code executed from request raiser to request handler

                // Invoke next middleware component
                await next();

                // Start of code executed from request handler to request raiser
                //await ctx.Response.WriteAsync("<p>On request handler of literal middleware</p>");
                //Debug.WriteLine("<p>On request handler of literal middleware</p>");
                // End of code executed from request handler to request raiser
            });

            // Use of not static middleware class
            app.Use<ClassMiddleware>();

            // Use of static middleware class
            app.UseStaticClassMiddleware();
        }
    }

    // Example 2: Class implementation
    public class ClassMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> next;

        public ClassMiddleware(AppFunc next)
        {
            this.next = next;
        }
        public async Task Invoke(IDictionary<string, object> environment)
        {
            // Start of code executed from request raiser to request handler

            // Get the ResponseBody Stream
            //var requestResponse = environment["owin.ResponseBody"] as Stream;
            //using (var writer = new StreamWriter(requestResponse))
            //{
            //    // Write response
            //    await writer.WriteAsync("<p>On request raiser of class middleware</p>");
            //}
            //Debug.WriteLine("On request raiser of class middleware");
            // End of code executed from request raiser to request handler

            // Invoke next middleware component
            await next.Invoke(environment);

            // Start of code executed from request handler to request raiser 

            // Get the ResponseBody Stream
            //var handlerResponse = environment["owin.ResponseBody"] as Stream;
            //using (var writer = new StreamWriter(handlerResponse))
            //{
            //    // Write response
            //    await writer.WriteAsync("<p>On request handler of class middleware</p>");
            //}
            //Debug.WriteLine("On request handler of class middleware");
            // End of code executed from request handler to request raiser 

        }
    }

    // Example 3: Static class implementation
    // First an static class is needed. This class will have an static method that will receive IAppBuilder as parameter
    // This method will call the use method of IAppBuilder to inject the StaticClassMiddleware
    public static class AppBuilderExtensions
    {
        public static void UseStaticClassMiddleware(this IAppBuilder app)
        {
            app.Use<StaticClassMiddleware>();
        }
    }

    // The static class middleware will be pretty much the same as not static class middleware implementated before
    public class StaticClassMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> next;

        public StaticClassMiddleware(AppFunc next)
        {
            this.next = next;
        }
        public async Task Invoke(IDictionary<string, object> environment)
        {
            // Start of code executed from request raiser to request handler

            // Get the ResponseBody Stream
            //var requestResponse = environment["owin.ResponseBody"] as Stream;
            //using (var writer = new StreamWriter(requestResponse))
            //{
            //    // Write response
            //    await writer.WriteAsync("<p>On request raiser of <b>static</b> class middleware</p>");
            //}
            //Debug.WriteLine("On request raiser of static class middleware");
            // End of code executed from request raiser to request handler

            // Invoke next middleware component
            await next.Invoke(environment);

            // Start of code executed from request handler to request raiser 
            // Get the ResponseBody Stream
            //var handlerResponse = environment["owin.ResponseBody"] as Stream;
            //using (var writer = new StreamWriter(handlerResponse))
            //{
            //    //Write response
            //    await writer.WriteAsync("<p>On request handler of <b>static</b> class middleware</p>");
            //}
            //Debug.WriteLine("On request handler of static class middleware");
            // End of code executed from request handler to request raiser 

        }
    }
}