using System;
using Microsoft.EntityFrameworkCore;
using TiendaServicio.api.CarritoCompra.Modelo;

namespace TiendaServicio.api.CarritoCompra.Persistencia
{
    public class CarritoContexto :DbContext
    {
        public CarritoContexto(DbContextOptions<CarritoContexto> options):base(options){}
        public DbSet<CarritoSesion> CarritoSesion { get; set; }
        public DbSet<CarritoSesionDetalle> CarritoSesionDetalle { get; set; }
    }
}
