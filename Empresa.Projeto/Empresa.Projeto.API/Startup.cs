using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Empresa.Projeto.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddJwtTConfiguration(Configuration);
            services.AddFluentValidationConfiguration();
            services.AddAutoMapperConfiguration();
            services.AddDatabaseConfiguration(Configuration);
            services.AddDependencyInjectionConfiguration();
            services.AddSwaggerConfiguration();
            services.AddCorsConfiguration(Configuration);
            services.AddVersionConfiguration();             
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();               
            }

            app.UseDatabaseConfiguration();
            app.UseSwaggerConfiguration(env);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}