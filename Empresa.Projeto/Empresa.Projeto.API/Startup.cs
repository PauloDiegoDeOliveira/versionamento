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

            #region :: CORS ::

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    var origins = Configuration.GetValue<string>("CorsOrigins").Split(";");
                    builder
                        .WithOrigins(origins)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            #endregion :: CORS ::

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Empresa.Projeto.API", Version = "v1" });
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Empresa.Projeto.API v1"));
            }

            app.UseDatabaseConfiguration();

            app.UseSwaggerConfiguration(env);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            //app.UseJwtConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}