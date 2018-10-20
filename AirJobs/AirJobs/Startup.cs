using AirJobs.Data.Context;
using AirJobs.Data.UnitOfWork;
using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AirJobs
{
    public class Startup
    {
        #region Constructor and Properties

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        public void ConfigureServices(IServiceCollection services)
        {
            #region MVC

            services.AddMvc();

            #endregion

            #region Database

            services.AddDbContext<AirJobsContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            #endregion

            #region IdentityServer

            services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration.GetValue<string>("IdentityServerUrl");
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "AirJobsApi";
                });

            #endregion

            #region IoC

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Swagger

            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1", new Info { Title = "AirJobs", Version = "v1", Contact = new Contact { Name = "AirJobs", Email = "airjobs@outlook.com.br" } });
            });

            #endregion

            #region AutoMapper

            services.AddAutoMapper();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AirJobs API");
            });

            app.UseMvc();
        }
    }
}
