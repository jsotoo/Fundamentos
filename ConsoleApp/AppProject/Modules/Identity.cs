using AppProject.Core.Module;
using AppProject.Core.Print;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Modules
{
    public class Identity : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public Identity() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        /*
        * 1. Open Package manager console.
        * 2. Install package: install-package Microsoft.AspNet.Identity.Core
        * 3. Install package: install-package Microsoft.AspNet.Identity.EntityFramework
        * 4. Add connection string named DefaultConnection (it have to be called this way by convention because identity will look for it)
        * 5. Create user manager class: This class contains all of the create, read, update, delete methods to managing identity data
        *    It does have methods for managing passwords, claims and roles for a user. Use the Identity default user class IdentityUser
        *    We most pass a user store to the constructor of the user manager class and it is user store
        *    The user store is the abstraction of the underline store layer, which is the database.
        * 6. Create an user. Username is mandatory
        * 7. Create a claim.
        * 8. Check password.
        */

        public void Init()
        {
            var username = "christian@hotmail.com";
            var password = "Tina12345*";
            var claimType = "given_name";
            var claimValue = "andrade";

            #region [IDENTITY]

            //var userStore = new UserStore<IdentityUser>();
            //var userManager = new UserManager<IdentityUser>(userStore);
            //var roleStore = new RoleStore<IdentityRole>();
            //var roleManager = new RoleManager<IdentityRole, string>(roleStore);

            //// 6. Create an user
            //var creationResult = userManager.Create(new IdentityUser(username), password);
            //Console.WriteLine("Created: {0}", creationResult.Succeeded);

            //// Find user by UserName
            //var user = userManager.FindByName(username);

            //// 7. Add a claim to the created user
            //var claimResult = userManager.AddClaim(user.Id, new Claim(claimType, claimValue));
            //Console.WriteLine("Claim: {0}", claimResult.Succeeded);

            //// 8. Check password
            //var isMatch = userManager.CheckPassword(user, password);
            //Console.WriteLine("Password Match: {0}", isMatch);

            //// 9. Crear role
            //roleManager.Create(new IdentityRole("Admin"));

            //userManager.AddToRoles(user.Id, "Admin");

            #endregion

            #region [CUSTOM]

            var userStore = new CustomUserStore(new CustomUserDbContext());
            var userManager = new UserManager<CustomUser, int>(userStore);

            // 6.Create an user
            var creationResult = userManager.Create(new CustomUser { UserName = username }, password);
            Console.WriteLine("Created: {0}", creationResult.Succeeded);

            //// Find user by UserName
            var user = userManager.FindByName(username);

            // 7. Add a claim to the created user
            var claimResult = userManager.AddClaim(user.Id, new Claim(claimType, claimValue));
            Console.WriteLine("Calim: {0}", claimResult.Succeeded);

            // 8. Check password
            var isMatch = userManager.CheckPassword(user, password);
            Console.WriteLine("Password Match: {0}", isMatch);

            #endregion

            Console.ReadLine();
        }

        #region [CUSTOM]
        public class CustomUser : IUser<int>
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string PasswordHash { get; set; }
        }

        public class CustomUserDbContext : DbContext
        {
            public CustomUserDbContext() : base("DefaultConnection") { }
            public DbSet<CustomUser> Users { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                var user = modelBuilder.Entity<CustomUser>();
                user.ToTable("Users");
                user.HasKey(x => x.Id);
                user.Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

                user.Property(x => x.UserName).IsRequired().HasMaxLength(256).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));

                base.OnModelCreating(modelBuilder);
            }
        }

        public class CustomUserStore : IUserPasswordStore<CustomUser, int>
        {
            private readonly CustomUserDbContext context;

            public CustomUserStore(CustomUserDbContext context)
            {
                this.context = context;
            }
            public void Dispose()
            {
                context.Dispose();
            }

            public Task CreateAsync(CustomUser user)
            {
                context.Users.Add(user);
                return context.SaveChangesAsync();
            }

            public Task UpdateAsync(CustomUser user)
            {
                context.Users.Attach(user);
                return context.SaveChangesAsync();
            }

            public Task DeleteAsync(CustomUser user)
            {
                context.Users.Remove(user);
                return context.SaveChangesAsync();
            }


            public Task<CustomUser> FindByIdAsync(int userId)
            {
                return context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            }

            public Task<CustomUser> FindByNameAsync(string userName)
            {
                return context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            }

            public Task SetPasswordHashAsync(CustomUser user, string passwordHash)
            {
                user.PasswordHash = passwordHash;
                return Task.CompletedTask;
            }

            public Task<string> GetPasswordHashAsync(CustomUser user)
            {
                return Task.FromResult(user.PasswordHash);
            }

            public Task<bool> HasPasswordAsync(CustomUser user)
            {
                return Task.FromResult(user.PasswordHash != null);
            }

        }

        //public class CustoRoleStore : IRoleStore<CustomRole>
        //{
        //    public Task CreateAsync(CustomRole role)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task DeleteAsync(CustomRole role)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Dispose()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<CustomRole> FindByIdAsync(string roleId)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<CustomRole> FindByNameAsync(string roleName)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task UpdateAsync(CustomRole role)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        #endregion
    }
}
