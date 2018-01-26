using System;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Identity.API.Infrastructure;
using Identity.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNet.Security.OpenIdConnect.Primitives;

namespace Identity.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connection = "Server=OVAISPC\\sqlexpress;Database=FraymsIdentityDB;User Id=sa;Password=P@ssw0rd;";
            
            //services.AddDbContext<BFIdentityContext>(options => options.UseSqlServer(connection));

            //services.AddEntityFrameworkSqlServer().AddDbContext<BFIdentityContext>(options =>
            //options.UseSqlServer(connection));

            services.AddDbContext<BFIdentityContext>(options =>
            {
                // Configure the context to use an in-memory store.
                //options.UseInMemoryDatabase(nameof(DbContext));

                options.UseSqlServer(connection);
                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need
                // to replace the default OpenIddict entities.
                options.UseOpenIddict();
                
                
                
                
                });


            services.AddIdentity<UserEntity, UserRoleEntity>()
                .AddEntityFrameworkStores<BFIdentityContext>()
                .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });


            services.AddOpenIddict(options =>
            {
                // Register the Entity Framework stores.
                options.AddEntityFrameworkCoreStores<BFIdentityContext>();
                // Register the ASP.NET Core MVC binder used by OpenIddict.
                // Note: if you don't call this method, you won't be able to
                // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                options.AddMvcBinders();
                // Enable the token endpoint.
                options.EnableTokenEndpoint("/connect/token");
                // Enable the password flow.
                options.AllowPasswordFlow();
                options.AllowRefreshTokenFlow();

                options.SetAccessTokenLifetime(TimeSpan.FromHours(5));
                options.SetRefreshTokenLifetime(TimeSpan.FromHours(10));
                // During development, you can disable the HTTPS requirement.
                options.DisableHttpsRequirement();
            });





            // services.AddAuthentication().AddOAuthValidation();

            //services.AddIdentity<UserEntity, UserRoleEntity>().AddEntityFrameworkStores<BFIdentityContext>().AddDefaultTokenProviders();


            //// Register the validation handler, that is used to decrypt the tokens.
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = OAuthValidationDefaults.AuthenticationScheme;
            }).AddOAuthValidation();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //var roleManager = app.ApplicationServices
                //    .GetRequiredService<RoleManager<UserRoleEntity>>();

                //var userManager = app.ApplicationServices.GetRequiredService<UserManager<UserEntity>>();

                //AddTestUser(roleManager, userManager).Wait();

            }

            

            app.UseAuthentication();
             app.UseMvc();
        }

        private static async Task AddTestUser(RoleManager<UserRoleEntity> roleManager, UserManager<UserEntity> userManager)
        {
            await roleManager.CreateAsync(new UserRoleEntity("Admin"));

            var user = new UserEntity
            {
                FirstName = "Ovais",
                LastName = "Khan",
                Email = "ovaismehboob@yahoo.com",
                VendorId = 1,
                CreatedAt = DateTimeOffset.Now
            };

            await userManager.CreateAsync(user, "P@ssw0rd");
            await userManager.AddToRoleAsync(user, "Admin");
            await userManager.UpdateAsync(user);
        }
    }
}
