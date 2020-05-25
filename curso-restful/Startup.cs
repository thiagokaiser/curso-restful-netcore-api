using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curso_restful.Contexts;
using curso_restful.Hypermedia;
using curso_restful.Interfaces;
using curso_restful.Models;
using curso_restful.Repositories;
using curso_restful.Repositories.Generic;
using curso_restful.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace curso_restful
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
            services.AddScoped<PersonService>();
            services.AddScoped<BookService>();
            services.AddScoped<FileService>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IBookRepository, BookRepository>();            

            services.AddDbContext<MyDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("CursoRESTful")));

            services.AddApiVersioning();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new Microsoft.OpenApi.Models.OpenApiInfo 
                    { 
                        Title = "Curso RESTful", 
                        Version = "v1" 
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("DefaultApi", "{controller=Values}/{id?}");
            });            
        }
    }
}
