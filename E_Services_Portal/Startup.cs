using E_Services_Portal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System.Configuration;

namespace E_Services_Portal
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            // Add other services
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the app
        }
    }
}




