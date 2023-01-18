using System;
using System.Threading.Tasks;
using TiendaServicio.api.CarritoCompra.RemoteModel;

namespace TiendaServicio.api.CarritoCompra.RemoteInterface
{
    public interface ILibroService
    {
        Task<(bool resultado, LibroRemote Libro, string ErrorMessage)> GetLibro(Guid LibroId);
    }
}
