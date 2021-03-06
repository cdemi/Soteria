using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Soteria.Data;
using MaxMind.GeoIP2;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Soteria.WebAPI.Models;
using Soteria.RiskScore;
using Soteria.HaveIBeenPwned;
using System;

namespace Soteria.WebAPI
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
            services.AddDbContext<SoteriaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SoteriaContext"), builder => builder.MigrationsAssembly("Soteria.Data.SqlServer")));

            // Configure to read configuration options from MaxMind section
            services.Configure<WebServiceClientOptions>(Configuration.GetSection("MaxMind"));
            // Configure dependency injection for WebServiceClient
            services.AddHttpClient<WebServiceClient>();

            services.AddHttpClient<IHaveIBeenPwnedService, HaveIBeenPwnedService>(client =>
            {
                client.BaseAddress = new Uri("https://api.pwnedpasswords.com/");
            });

            services.AddScoped<RiskCalculator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Soteria API", Version = "v1" });
                c.ExampleFilters();
            });
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SoteriaContext>())
                {
                    context.Database.Migrate();
                }
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Soteria API");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
