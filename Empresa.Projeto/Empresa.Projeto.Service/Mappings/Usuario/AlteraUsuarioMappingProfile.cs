using AutoMapper;
using Empresa.Projeto.Domain;
using System;

namespace Empresa.Projeto.Service
{
    public class AlteraUsuarioMappingProfile : Profile
    {
        public AlteraUsuarioMappingProfile()
        {
            CreateMap<PutUsuario, Usuario>()
                 .ForMember(d => d.AlteradoEm, o => o.MapFrom(x => DateTime.Now));
        }
    }
}