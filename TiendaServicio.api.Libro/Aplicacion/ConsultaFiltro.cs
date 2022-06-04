using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.api.Libro.Modelo;
using TiendaServicio.api.Libro.Persistencia;

namespace TiendaServicio.api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : MediatR.IRequest<LibreriaMaterialDto>
        {
            public Guid? LibroId { get; set; }

        }
        public class Manejador : IRequestHandler<LibroUnico, LibreriaMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<LibreriaMaterialDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var Libro = await _contexto.LibreriaMaterial.Where(x => x.LibreriaMaterialId == request.LibroId).FirstOrDefaultAsync();

                if(Libro == null)
                {
                    throw new Exception("No se encontro el libro");
                }
                var LibroDto = _mapper.Map<LibreriaMaterial, LibreriaMaterialDto>(Libro);

                return LibroDto;
            }
        }
    }
}
