using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebAPI.DbOperations;
using WebAPI.Services;

namespace WebAPI
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
                       {
                           opt.TokenValidationParameters = new TokenValidationParameters()
                           {
                               ValidateAudience = true,
                               ValidateIssuer = true,
                               ValidateLifetime = true,
                               ValidateIssuerSigningKey = true,
                               ValidIssuer = Configuration["Token:Issuer"], // yayinlayici
                               ValidAudience = Configuration["Token:Audience"], // hedef kitle
                               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                               ClockSkew = TimeSpan.Zero // Token'i ureten sunucunun zamani ile kullanicilarin zamani farkli ise, bizde 0
                           };
                       });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
            //Mssql db bağlantısı
            services.AddDbContext<MovieDbContext>(options =>
             options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            //her bir requeste karşı yeni bir request oluşturması için
            services.AddScoped<IMovieDbContext>(provider => provider.GetService<MovieDbContext>());
            //nesne eşleştirmesi için
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //loglama işlemi için
            services.AddSingleton<ILoggerService, ConsoleLogger>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseAuthentication(); //Bu olmadan Authorization olmak olmaz öncelik bu kısım

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
