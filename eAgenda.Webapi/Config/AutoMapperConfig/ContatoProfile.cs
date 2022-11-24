using AutoMapper;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Webapi.ViewModels.ModuloContato;
using System;

namespace eAgenda.Webapi.Config.AutoMapperConfig
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<FormsContatoViewModel, Contato>()
                .ForMember(destino => destino.Id, opt => opt.Ignore())
                .ForMember(destino => destino.TituloFoto, opt => opt.MapFrom(origem => origem.TituloFoto + "_" + Guid.NewGuid() + ".jpg"))
                .ForMember(destino => destino.ConteudoFoto, opt => opt.MapFrom( origem => Convert.FromBase64String(origem.ConteudoFoto)))
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>());

            CreateMap<Contato, ListarContatoViewModel>();

            CreateMap<Contato, VisualizarContatoViewModel>()
                .ForMember(destino => destino.Compromissos, opt => opt.MapFrom(origem => origem.Compromissos));

            CreateMap<Contato, FormsContatoViewModel>();
        }        
    }
}