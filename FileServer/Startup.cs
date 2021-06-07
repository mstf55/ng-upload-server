using FileServer.App.Interfaces;
using FileServer.App.Services;
using FileServer.Core.Repositories;
using FileServer.Core.Repositories.Base;
using FileServer.Infrastructure.Repositories;
using FileServer.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileServer.Interfaces;
using FileServer.Service;
using FileServer.Infrastructure.Data;
using FileServer.Middleware;

namespace FileServer
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
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IFileRepository, FileRepository>();

            services.AddScoped<IFileService, FileService>();

            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddScoped<IFileFrontService, FileFrontService>();


            services.AddDbContext<FileDbContext>(opt => opt.UseInMemoryDatabase(databaseName:"test"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
          options.WithOrigins("http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
