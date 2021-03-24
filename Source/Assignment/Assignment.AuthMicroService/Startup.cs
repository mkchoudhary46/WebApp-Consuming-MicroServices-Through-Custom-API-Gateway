using Assignment.AuthMicroService.Services;
using Assignment.AuthMicroService.Services.Implementations;
using Assignment.BusinessLogic.Contracts;
using Assignment.BusinessLogic.Implementations;
using Assignment.Common.ConfigurationProvider;
using Assignment.Common.Utility;
using Assignment.Data;
using Assignment.Mappers;
using Assignment.Repositories.Common.Contracts;
using Assignment.Repositories.Common.Implementations;
using Assignment.Repositories.Contracts;
using Assignment.Repositories.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Assignment.AuthMicroService
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
            var cs = Configuration.GetConnectionString("DeafultConnection");

            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(cs);
            });


            //jwt token validation 
            services.AddJwtAuthentication(Configuration); // Extension for JWT


            services.Configure<AppSettings>(Configuration.GetSection("AppSetting"));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IEmployeeLogic, EmployeeLogic>();
            services.AddScoped<ITokenBuilder, TokenBuilder>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

          
            services.AddScoped<IEmployeeLogic, EmployeeLogic>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        );
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
