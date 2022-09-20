using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Models;
using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;

namespace OnBoard.WebApp
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
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddOptions();

            //Create context to database with all of the Board & Commission information...
            services.AddDbContext<DataModelDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //Create context to database with all of the ASP.NET Users and Roles information...
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            //Add ASP.NET Identity...
            services.AddIdentity<AppUserModels, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>() //EF Core
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            //Require cookies...
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Base services / repositories...
            services.AddScoped<IBaseService<Application>, BaseService<Application>>();
            services.AddScoped<IBaseService<ApplicationQuestion>, BaseService<ApplicationQuestion>>();
            services.AddScoped<IBaseService<Commission>, BaseService<Commission>>();
            services.AddScoped<IBaseService<CommissionApplication>, BaseService<CommissionApplication>>();
            services.AddScoped<IBaseService<CommissionMember>, BaseService<CommissionMember>>();
            services.AddScoped<IBaseService<ApplicationExtended>, BaseService<ApplicationExtended>>();

            //Services...
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<ICommissionService, CommissionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Decide whether to show errors to the user or not...
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Error");

            app.UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication(); //ASP.NET authentication users/roles
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthorization(); //ASP.NET authorization users/roles (need this line also)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}