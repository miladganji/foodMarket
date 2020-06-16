using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using Application.PipeLine.User;
using Microsoft.OpenApi.Models;
using Application.PipeLine.EvenSourcing;
using Application.Services.User;
using Application.Repositories.User;

namespace trainingFoodMarket
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
            //var secretkey = Encoding.UTF8.GetBytes("LongerThan-16Char-SecretKey");
            //var encryptionkey = Encoding.UTF8.GetBytes("16CharEncryptKey");


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "food Market Api Documentation", Version = "v1" });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ApplicationDbContext>(config=> {
                config.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            },ServiceLifetime.Transient);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
 var secretkey = Encoding.UTF8.GetBytes("LongerThan-16Char-SecretKey");
 var encryptionkey = Encoding.UTF8.GetBytes("16CharEncryptKey");

 var validationParameters = new TokenValidationParameters
 {
     ClockSkew = TimeSpan.Zero, // default: 5 min
        RequireSignedTokens = true,

     ValidateIssuerSigningKey = true,
     IssuerSigningKey = new SymmetricSecurityKey(secretkey),

     RequireExpirationTime = true,
     ValidateLifetime = true,

     ValidateAudience = true, //default : false
        ValidAudience = "readers",

     ValidateIssuer = true, //default : false
        ValidIssuer = "milad ganji",

     TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
 };

 options.RequireHttpsMetadata = false;
 options.SaveToken = true;
 options.TokenValidationParameters = validationParameters;
});
            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IPipelineBehavior<CreateUserCommand, Guid>), typeof(CreateUserCommandPipeline<CreateUserCommand, Guid>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(eventSourcingPipeline<,>));
            services.AddTransient<IUserRepository, Userrepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
