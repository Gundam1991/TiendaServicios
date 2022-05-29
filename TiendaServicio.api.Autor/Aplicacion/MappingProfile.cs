using AutoMapper;
using TiendaServicio.api.Autor.Modelo;

namespace TiendaServicio.api.Autor.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorLibro, AutorDto>();
        }
    }
}
