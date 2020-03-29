using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
using splitourbill_backend.Mappings;
using splitourbill_backend.Persistence;
using splitourbill_backend.Requirements;

namespace splitourbill_backend
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
            services.AddControllers();

            services.AddCors(setupAction =>
            {
                setupAction.AddPolicy("allow clients", configurePolicy =>
                {
                    configurePolicy
                        .WithOrigins(Configuration.GetSection("Security:AllowedCorsOrigins").Get<string[]>())
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var auth0Domain = $"https://{Configuration.GetSection("Auth0:Domain").Get<string>()}/";
            services.AddAuthentication(configureOptions =>
            {
                configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.Authority = auth0Domain;
                configureOptions.Audience = Configuration.GetSection("Auth0:ApiIdentifier").Get<string>();
                configureOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });
            services.AddAuthorization(configure =>
            {
                configure.AddPolicy("read:users", policy => policy.Requirements.Add(new HasPermissionRequirement("read:users", auth0Domain)));
                configure.AddPolicy("read:friendships", policy => policy.Requirements.Add(new HasPermissionRequirement("read:friendships", auth0Domain)));
                configure.AddPolicy("write:friendships", policy => policy.Requirements.Add(new HasPermissionRequirement("write:friendships", auth0Domain)));
            });
            services.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();

            services.AddSwaggerGen(setupAction => setupAction.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Backend Service",
                Version = "1"
            }));

            services.AddDbContext<BackendDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Default")));
            services.AddAutoMapper(configAction => configAction.AddProfile<BackendMappingProfile>(), typeof(Startup));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFriendshipRepository, FriendshipRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("allow clients");

            // app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(setupAction => setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend Service V1"));

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
