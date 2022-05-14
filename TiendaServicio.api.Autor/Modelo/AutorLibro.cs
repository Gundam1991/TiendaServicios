using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicio.api.Autor.Modelo
{
    public class AutorLibro
    {
        public int AutorLibroId { get; set; }
        public int Nombre { get; set; }
        public string Apelllido{ get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public ICollection<GradoAcademico> ListaGradoAcademico { get; set; }

        public string AutorLibroGuid { get; set; }
    }
}
