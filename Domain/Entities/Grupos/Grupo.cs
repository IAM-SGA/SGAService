using Domain.Entities.Usuarios;
using Domain.Interfaces.Grupos;

namespace Domain.Entities.Grupos
{
    public class Grupo
    {
        private List<UsuarioLDAP> usuarios;
        private string nombre;
        private readonly IGrupoRepository _grupoRepository;

        public Grupo(IGrupoRepository grupoRepository)
        {
            _grupoRepository = grupoRepository ?? throw new ArgumentNullException(nameof(grupoRepository));
            usuarios = new List<UsuarioLDAP>();
        }

        public async Task CrearAsync()
        {
            await _grupoRepository.CrearAsync(this);
        }

        public async Task ActualizarAsync()
        {
            await _grupoRepository.ActualizarAsync(this);
        }

        public async Task EliminarAsync()
        {
            await _grupoRepository.EliminarAsync(this);
        }

        public void AddUsuario(UsuarioLDAP usuario)
        {
            if (!usuarios.Contains(usuario))
            {
                usuarios.Add(usuario);
                usuario.AddGrupo(this);
            }
        }

        public void RemoveUsuario(UsuarioLDAP usuario)
        {
            if (usuarios.Contains(usuario))
            {
                usuarios.Remove(usuario);
                usuario.RemoveGrupo(this);
            }
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public IReadOnlyList<UsuarioLDAP> Usuarios => usuarios.AsReadOnly();

        public async Task CargarPorNombreAsync()
        {
            var grupo = await _grupoRepository.CargarPorNombreAsync(nombre);
            Copy(grupo);
        }

        private void Copy(Grupo grupo)
        {
            nombre = grupo.nombre;
            usuarios.AddRange(grupo.usuarios);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not Grupo grupo) return false;
            return string.Equals(nombre, grupo.nombre, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return nombre?.GetHashCode() ?? 0;
        }
    }
}
