using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicio.api.Libro.Modelo;
using TiendaServicio.api.Libro.Persistencia;

namespace TiendaServicio.api.Libro.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<LibreriaMaterialDto>>{ }
        public class Manejador : IRequestHandler<Ejecuta, List<LibreriaMaterialDto>>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<LibreriaMaterialDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var Libros = await _contexto.LibreriaMaterial.ToListAsync();

                var librosDto = _mapper.Map<List<LibreriaMaterial>, List<LibreriaMaterialDto>>(Libros);

                return librosDto;
            }
        }



    }
}
