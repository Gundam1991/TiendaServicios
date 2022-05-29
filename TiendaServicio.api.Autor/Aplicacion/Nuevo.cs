﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.api.Autor.Modelo;
using TiendaServicio.api.Autor.Persistencia;

namespace TiendaServicio.api.Autor.Aplicacion
{
    //Insertar nuevo Autor dentro Dde BD
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            //Parametros envia el controller
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }

        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            //
            public readonly ContextoAutor _contexto;

            //ContextoAutor DB
            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }


            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    FechaNacimiento = request.FechaNacimiento,
                    Apelllido = request.Apellido,
                    AutorLibroGuid = Convert.ToString(Guid.NewGuid()),
                };
                _contexto.AutorLibro.Add(autorLibro);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar los valores del libro");
            }
        }
    }
}
