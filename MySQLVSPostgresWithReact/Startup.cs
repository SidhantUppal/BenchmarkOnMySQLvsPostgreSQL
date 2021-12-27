using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySQLVSPostgresWithReact.DataAccessMySQL;
using MySql.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySQLVSPostgresWithReact.DataAccessPostgre;
using MysqlVSPostgresWithReact.Repositories;
using Microsoft.AspNetCore.Mvc;
using MySQLVSPostgresWithReact.Interfaces;
using MySQLVSPostgresWithReact.Repositories;

namespace MySQLVSPostgresWithReact
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddScoped<IScopedPassThrough, ScopedPassThrough>();

            services.AddDbContext<MySQLDbContext>(options =>
            {
                var connetionString = Configuration.GetConnectionString("MySQLConnection");
                options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
            });

            services.AddEntityFrameworkNpgsql().AddDbContext<PostgreSQLDbContext>(options =>
          options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));

            //var sqlConnectionString = Configuration.GetConnectionString("PostgreSQLConnection");  
            //services.AddDbContext<PostgreSQLDbContext>(options => options.UseNpgsql(sqlConnectionString));

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
