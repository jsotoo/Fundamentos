// To implement Identity and OWIN to an MVC application will use as an example the template of MVC application for .net framework 4.6 with no authentication.

// First install the next packages.

// This packages are needed to make Identity Work
// install-package Microsoft.AspNet.Identity.Owin -version 2.2.2 (demo is using 2.2.1)
// install-package Microsoft.AspNet.Identity.EntityFramework -version 2.2.2 (demo is using 2.2.1)
// The next reference should be added in the project
// Microsoft.AspNet.Identity.Core

// This package is needed to make MVC Work with OWIN and the IIS.
// install-package Microsoft.Owin.Host.SystemWeb -version 3.0.1 (demo is using 3.0.1)

// This package is needed to us authentication and authorization. The simples way to do this is using a cookie
// First we need to install the next package:
// install-package Microsoft.Owin.Security.Cookies -version 3.0.1
// This package let us add a middleware component that allow us to issue the cookie

// First lets create the configuration in the startup class

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(WebAppProject.StartupIdentity))]

namespace WebAppProject
{
    public class StartupIdentity
    {
        public void Configuration(IAppBuilder app)
        {
            const string connectionString = @"data source=BOGLANDRADE\SQLEXPRESS2017;initial catalog=IdentityOWINMVC;persist security info=True;user id=sa;password=Tina12345*;MultipleActiveResultSets=True;App=EntityFramework";

            // Create our IdentityDbContext passing the connection string
            // This will ensure that we'll have a new IdentityDbContext created per OWIN request
            app.CreatePerOwinContext(() => new IdentityDbContext(connectionString));
            // Register the implementation of UserStore, for this we need to pass in the current instance of IdentityDbContext
            app.CreatePerOwinContext<UserStore<IdentityUser>>((opt, context) => new UserStore<IdentityUser>(context.Get<IdentityDbContext>()));
            // Register the implementation of UserManager, for this, we need to pass in the current instance of UserStore
            app.CreatePerOwinContext<UserManager<IdentityUser>>((opt, context) => new UserManager<IdentityUser>(context.Get<UserStore<IdentityUser>>()));
            // Register the implementation of  SignInManager, for this we need to pass the current instance of the UserManager
            //app.CreatePerOwinContext((opt, context) => SignInManager<IdentityUser, string>(context.Get<UserManager<IdentityUser>>(), context.Authentication));
            app.CreatePerOwinContext<SignInManager<IdentityUser, string>>((opt, context) 
                => new SignInManager<IdentityUser, string>(context.Get<UserManager<IdentityUser>>(), context.Authentication));
            // Register the implementation of the CookieAuthentication
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}