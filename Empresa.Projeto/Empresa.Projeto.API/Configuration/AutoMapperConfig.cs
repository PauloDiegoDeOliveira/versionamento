using Empresa.Projeto.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Projeto.API
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(NovoUsuarioMappingProfile),
                typeof(AlteraUsuarioMappingProfile));
        }
    }
}
