﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using DotVVM.Framework.Routing;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();
            services.AddAuthorization();
            services.AddWebEncoders();
            services.AddDotVVM<DotvvmStartup>();
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("dotvvm")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dbContext)
        {
            var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(env.ContentRootPath);
            dotvvmConfiguration.AssertConfigurationIsValid();
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(env.WebRootPath)
            });

            if (env.IsDevelopment())
                dbContext.Database.EnsureCreated();
        }
    }
}
