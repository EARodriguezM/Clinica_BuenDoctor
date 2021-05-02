using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;

using BuenDoctorAPI.Models.Login;
using BuenDoctorAPI.Models.Data;

using BuenDoctorAPI.Repositories.Login;
using BuenDoctorAPI.Repositories.Data;

using BuenDoctorAPI.BLL.Login;
using BuenDoctorAPI.BLL.Data;

namespace BuenDoctorAPI
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
            services.AddDbContext<BuenDoctorLoginContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LoginConnection")));
            services.AddDbContext<BuenDoctorDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DataConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BuenDoctorAPI", Version = "v1" });
            });

            services.AddCors();

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddScoped<ILoginUserRepository, LoginUserRepository>();
            services.AddScoped<DataUserRepository>();
            services.AddScoped<DataUserBLL>();
            services.AddScoped<LoginUserBLL>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BuenDoctorAPI v1"));
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();


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
