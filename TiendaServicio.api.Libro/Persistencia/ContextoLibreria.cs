using Microsoft.EntityFrameworkCore;
using System;
using TiendaServicio.api.Libro.Models;

namespace TiendaServicio.api.Libro.Persistencia
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options){ }
        public DbSet<LibreriaMaterial> LibreriaMaterial { get; set;}
    }
}
