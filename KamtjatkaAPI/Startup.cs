using KamtjatkaAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using KamtjatkaAPI.Repositories;

namespace KamtjatkaAPI
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
            //retrieves connection string from appsettings
            services.AddDbContext<vujeeaxiContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("dbconn")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KamtjatkaAPI", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .WithOrigins("http://localhost:3000", "http://localhost:3000/BachelorWebApp")
                                      .AllowAnyHeader());
            });

            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentCategoryRepository, AppointmentCategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IFinanceRepository, FinanceRepository>();
            services.AddScoped<IFinanceCategoryRepository, FinanceCategoryRepository>();
            services.AddScoped<IKamtjatkaInfoRepository, KamtjatkaInfoRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomBookingRepository, RoomBookingRepository>();
            services.AddScoped<IRoomCategoryRepository, RoomCategoryRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IMessagesRepository, MessagesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KamtjatkaAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowOrigin"); 

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
