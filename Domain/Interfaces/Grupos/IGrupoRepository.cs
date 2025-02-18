using Domain.Entities.Usuarios;

namespace Domain.Interfaces.Grupos
{
    public interface IGrupoRepository
    {
        Task CrearAsync(Grupo grupo);
        Task ActualizarAsync(Grupo grupo);
        Task EliminarAsync(Grupo grupo);
        Task<Grupo> CargarPorNombreAsync(string nombre);
    }
}
