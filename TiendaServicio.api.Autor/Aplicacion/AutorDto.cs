using System;
using System.Collections.Generic;
using TiendaServicio.api.Autor.Modelo;

namespace TiendaServicio.api.Autor.Aplicacion
{
    public class AutorDto
    {
        public string Nombre { get; set; }
        public string Apelllido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
