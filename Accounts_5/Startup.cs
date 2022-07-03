using Accounts_5.ConfigServices;
using Accounts_5.Controllers;
using Accounts_5.Data;
using Accounts_5.IRepository;
using Accounts_5.Rebository;
using Accounts_5.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5
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
            services.AddDbContext<DatabaseContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
            services.AddAuthentication();
            services.ConfigureIdentity();
            services.Configurejwt(Configuration);


            services.AddCors(o =>
            {
                o.AddPolicy("CorePolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.ConfigureAutoMapper();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthoManger, AuthoManger>();
            //services.AddScoped<IGenericRepository<VaccinationCenter>,GenericRepository<VaccinationCenter>>();
            AddSweggerDoc(services);

            services.AddControllers().AddNewtonsoftJson(op =>
            op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }
        private void AddSweggerDoc(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {

                    Description = @"Jwt Authorization header using Bearer scheme.
                Enter 'Bearer' [space] and then your token in the text input belew.
                Example: 'Bearer 123456789'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference= new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme="0outh2",
                            Name="Bearer",
                            In=ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "COVID API",
                        Version = "v1"
                    });
                });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Accounts_5 v1"));
            }
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllers();
            });
        }
    }
}
