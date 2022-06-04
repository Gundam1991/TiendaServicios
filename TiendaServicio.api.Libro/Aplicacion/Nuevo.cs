using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using TiendaServicio.api.Libro.Modelo;
using TiendaServicio.api.Libro.Persistencia;

namespace TiendaServicio.api.Libro.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta: IRequest
        {
            public string Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public Guid? AutorLibro { get; set; }

        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.AutorLibro).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoLibreria _contexto;
            public Manejador(ContextoLibreria contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var Libro = new LibreriaMaterial
                {
                    Titulo = request.Titulo,
                    FechaPublicacion = request.FechaPublicacion,
                    AutorLibro = request.AutorLibro,
                };
                 _contexto.LibreriaMaterial.Add(Libro);
                var value = await _contexto.SaveChangesAsync();
                
                if(value >0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo giuardar el libro");
            }
        }
    }
}
