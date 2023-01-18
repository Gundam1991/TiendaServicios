using System;

namespace TiendaServicio.api.CarritoCompra.Aplicacion
{
    public class CarritoDetalleDto
    {
        public Guid? LibroId{ get; set; }
        public string TituloLibro{ get; set; }
        public string AuorLibro { get; set; } 
        public DateTime? FechaPublicacion { get; set; }
    }
}
