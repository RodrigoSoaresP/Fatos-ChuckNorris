using AutoMapper;
using Fatos.Modelo;
using Fatos.Service.Model;


namespace Fatos.Service.Mapeamento
{
    public class ConfigurarMapeamento : Profile
    {
        public ConfigurarMapeamento()
        {
            CreateMap<FatosModelRetorno, FatosModel>()

                .ForMember(dest => dest.FatosChuckNorris, opts => opts.MapFrom(src => src.value));
                //.ForMember(dest => dest.DataCriacao, opts => opts.MapFrom(src => src.value));


        }
    }

}
