using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.api.CarritoCompra.Persistencia;
using TiendaServicio.api.CarritoCompra.RemoteInterface;

namespace TiendaServicio.api.CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta:IRequest<CarritoDto>{
            public int CarritoSesionId { get; set; }
        
        }
        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly CarritoContexto _carritoContexto;
            private readonly ILibroService _libroService;

            public Manejador (CarritoContexto carritoContexto, ILibroService libroService)
            {
                _carritoContexto = carritoContexto;
                _libroService = libroService;
            }

            public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = await _carritoContexto.CarritoSesion.FirstOrDefaultAsync((x) => x.CarritoSesionId == request.CarritoSesionId);
                var carritoSesionDetalle = await _carritoContexto.CarritoSesionDetalle.Where((x) => x.CarritoSesionId == request.CarritoSesionId).ToListAsync();

                var carritoListaDto = new List<CarritoDetalleDto>();

                foreach (var lin in carritoSesionDetalle)
                {
                    var response = await _libroService.GetLibro(new Guid(lin.ProductoSeleccionado));
                    if (response.resultado)
                    {
                        var objetoLibro = response.Libro;
                        var carritoDetalle = new CarritoDetalleDto
                        {
                            TituloLibro = objetoLibro.Titulo,
                            FechaPublicacion = objetoLibro.FechaPublicacion,
                            LibroId = objetoLibro.LibreriaMaterialId
                        };
                        carritoListaDto.Add(carritoDetalle);
                    }
                };
                var carritoSesionDto = new CarritoDto
                {
                    CarritoId = carritoSesion.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion.FechaCreacion,
                    ListaProductos = carritoListaDto
                };

                return carritoSesionDto;
            }




        }
    }
}
