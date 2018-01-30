using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Introspection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vendor.Domain.Models.VendorModel;
using Vendor.Infrastructure;
using Vendor.Infrastructure.Repositories;

namespace Vendor.API
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
            services.AddScoped<VendorDBContext>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddMediatR();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = OAuthIntrospectionDefaults.AuthenticationScheme;
            }).AddOAuthIntrospection(options =>
             {
                 options.Authority = new Uri("http://localhost:22440/");
                 options.Audiences.Add("vendor-api");
                 options.ClientId = "vendor-api";
                 options.ClientSecret = "846B62D0-DEF9-4215-A99D-86E6B8DAB342";
                 options.RequireHttpsMetadata = false;

                    // Note: you can override the default name and role claims:
                    // options.NameClaimType = "custom_name_claim";
                    // options.RoleClaimType = "custom_role_claim";
                });



            services.AddMvc();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<VendorDBContext>(options =>
                {
                    options.UseSqlServer(Configuration["ConnectionString"],
                        sqlServerOptionsAction: sqlOptions =>
                       {
                           sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                           sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                       });
                }, ServiceLifetime.Scoped
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
