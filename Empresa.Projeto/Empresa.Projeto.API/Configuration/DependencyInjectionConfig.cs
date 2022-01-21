using Empresa.Projeto.Infra;
using Empresa.Projeto.Infra.Repositories;
using Empresa.Projeto.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Empresa.Projeto.API
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}

/*
Objetos transitórios são sempre diferentes; uma nova instância é fornecida para todo controlador e todo serviço.

Objetos com escopo definido são os mesmos em uma solicitação, mas diferentes entre solicitações diferentes.

Objetos Singleton são os mesmos para todos os objetos e solicitações.
*/