using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TechCodeLib.DAL;
using TechCodeLib.Repositories;
using TechCodeLib.Services;
using TechCodeLib.Services.Contract;
using static TechCodeLib.Infrastructure.Common.Constants;

namespace TechCodeLibAPI
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
            services.AddDbContext<TechCodeLibContext>(
                op => op.UseSqlServer(Configuration.GetConnectionString("TechCodeLibDb")));
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<TechCodeLibUoW>();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration[WebConfig.TOKEN_ISSUER],
                    ValidAudience = Configuration[WebConfig.TOKEN_AUDIENCE],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[WebConfig.TOKEN_SIGNING_KEY]))
                };


            });
            services.AddAuthorization();
            services.AddCors(options => options.AddPolicy("TechCodeLibCorsPolicy", builder =>
            {
                builder
                    .WithOrigins(@"http://localhost:4200")
                    .AllowAnyMethod()//("GET, POST, PUT, DELETE, OPTIONS")
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("TechCodeLibCorsPolicy");

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
