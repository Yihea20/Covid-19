using Accounts_5.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_5.ConfigServices
{
    public static class ServicesExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<Person>(
                q => q.User.RequireUniqueEmail = true
                );
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddTokenProvider("CovidApi", typeof(DataProtectorTokenProvider<Person>));
            builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
        }
        public static void Configurejwt(this IServiceCollection services, IConfiguration Configuration)
        {

            var jwtSetting = Configuration.GetSection("jwt");
            var key = Environment.GetEnvironmentVariable("KEY");
            services.AddAuthentication(
                o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSetting.GetSection("Issuer").Value,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    };
                });
        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error($"Something Want Wrong in the {contextFeature.Error}");
                        await context.Response.WriteAsync(new Error
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error, Please Try Again Later."
                        }.ToString()
                        );
                    }
                });
            });
        }
    }
}
