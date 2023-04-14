
using BPR.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Design;
using BPR.API.Repositories;

namespace WebApplication1
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
            string apiKey = Configuration.GetValue<string>("ElephantSqlApiKey");

            // uzycie DBConnection w appsettings.json
            services.AddDbContext<MyDBContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DBConnection")));
            //services.AddDbContext<MyDBContext>(o => o.UseNpgsql("Data source=vujeeaxi"));
            services.AddControllers();
            services.AddScoped<IRoomCategoryRepository, RoomCategoryRepository>();

             
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
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


        }
    }
}
