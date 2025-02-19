using Domain.Entities.Usuarios;

namespace Domain.Entities.Operacion
{
    public abstract class OperacionUsuario
    {
        protected Usuario usuario;

        public abstract Task Ejecutar();

        public bool EsCritica() => usuario.IsAplicacionCritica();

        public Usuario GetUsuario() => usuario;

        public void SetUsuario(Usuario usuario) => this.usuario = usuario;
    }
}