using AutoMapper;
using System;
using TiendaServicio.api.Libro.Modelo;

namespace TiendaServicio.api.Libro.Aplicacion
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibreriaMaterialDto>();
        }
    }
}
