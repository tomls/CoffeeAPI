using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CoffeeApi.Models;

namespace CoffeeApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services.Configure<MvcOptions>(options =>
            // {
            //     options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            // });
            // services.AddCors();
             services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials() );
                });

            services.AddDbContext<CoffeeContext>(opt => 
                opt.UseInMemoryDatabase("CoffeeList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
          
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
