using Domain.Entities.Novedades;

namespace Domain.Interfaces.Novedades
{
    public interface INovedadRepository
    {
        Task CrearAsync(Novedad novedad);
        Task ActualizarAsync(Novedad novedad);
        Task EliminarAsync(Novedad novedad);
        Task<List<Novedad>> ObtenerNovedadesAprobadasAsync(long nroInstancia);
    }
}
