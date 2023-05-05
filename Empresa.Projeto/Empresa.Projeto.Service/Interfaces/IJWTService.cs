using Empresa.Projeto.Domain;

namespace Empresa.Projeto.Service
{
    public interface IJWTService
    {
        string GerarToken(Usuario usuario);
    }
}