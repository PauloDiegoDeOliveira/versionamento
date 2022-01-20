using AutoMapper;
using Empresa.Projeto.Domain;
using System;

namespace Empresa.Projeto.Service
{
    public class NovoUsuarioMappingProfile : Profile
    {
        public NovoUsuarioMappingProfile()
        {
            CreateMap<PostUsuario, Usuario>()
                  .ForMember(d => d.CriadoEm, o => o.MapFrom(x => DateTime.Now));

            CreateMap<Usuario, ViewUsuario>();

            CreateMap<Usuario, ViewLogin>().ReverseMap();
        }
    }
}