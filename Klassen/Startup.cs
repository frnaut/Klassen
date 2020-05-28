using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.AppContext;
using Core.IRepository;
using Core.Managers;
using Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Klassen
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
            services.AddMvc().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnetion")));

            services.AddTransient<AssignmetManager>();
            services.AddTransient<ClassroomManager>();
            services.AddTransient<DeliveryManager>();
            services.AddTransient<DocumentDeliveryManager>();
            services.AddTransient<DocumentManager>();
            services.AddTransient<PostManager>();
            services.AddTransient<RoleManager>();
            services.AddTransient<UserStudentManager>();
            services.AddTransient<UserTeacherManager>();

            services.AddScoped<IAssignmentsRepository, AssingmentRepository>();
            services.AddScoped<IClassroomRepository, ClassroomRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IDocumentDeliveryRepository, DocumentDeliveryRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserStudentRepository, UserStudentRepository>();
            services.AddScoped<IUserTeacherRepository, UserTeacherRepository >();


            services.AddSwaggerGen(conf =>
            {
                conf.SwaggerDoc("Klassen", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "Klassen",
                    Description = "Web api para aplicacion de clases en lineas"

                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/Klassen/swagger.json", name: "Klassen API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
