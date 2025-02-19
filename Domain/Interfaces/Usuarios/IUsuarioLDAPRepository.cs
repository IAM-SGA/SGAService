using Domain.Entities.Grupos;
using Domain.Entities.Usuarios;

namespace Domain.Interfaces.Usuarios
{
    public interface IUsuarioLDAPRepository
    {
        Task CrearAsync(UsuarioLDAP usuario);
        Task ModificarClaveYEstadoAsync(UsuarioLDAP usuario);
        Task AccesoAlWebServiceExchangeAsync(UsuarioLDAP usuario);
        Task EliminarAsync(UsuarioLDAP usuario);
        Task ActualizarAsync(UsuarioLDAP usuario);
        Task AgregarUsuarioAGrupoAsync(UsuarioLDAP usuario, Grupo grupo);
        Task BorrarUsuarioDeGrupoAsync(UsuarioLDAP usuario, Grupo grupo);
    }
}
