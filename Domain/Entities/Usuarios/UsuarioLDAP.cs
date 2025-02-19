using Domain.Entities.Grupos;
using Domain.Interfaces.Usuarios;

namespace Domain.Entities.Usuarios
{
    [Serializable]
    public class UsuarioLDAP : Usuario
    {
        private readonly IUsuarioLDAPRepository _repositorioUsuarioLDAP;
        private readonly List<Grupo> _grupos;

        public bool TieneInternet { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; } = true;
        public bool ClaveExpirada { get; set; } = true;
        public string RutaRelativa { get; set; }
        public string Dominio { get; set; }
        public int DuracionClave { get; set; } = 45;
        public string PrefijoNombreAMostrar { get; set; }
        public bool TieneVPN { get; set; }

        public List<Grupo> Grupos => _grupos;

        public UsuarioLDAP(IUsuarioLDAPRepository repositorioUsuarioLDAP)
        {
            _repositorioUsuarioLDAP = repositorioUsuarioLDAP ?? throw new ArgumentNullException(nameof(repositorioUsuarioLDAP));
            _grupos = new List<Grupo>();
        }

        public override async Task CrearAsync()
        {
            await _repositorioUsuarioLDAP.CrearAsync(this);
            await _repositorioUsuarioLDAP.ModificarClaveYEstadoAsync(this);
        }

        public override async Task ActualizarAsync()
        {
            await _repositorioUsuarioLDAP.ActualizarAsync(this);
        }

        public override async Task EliminarAsync()
        {
            await _repositorioUsuarioLDAP.EliminarAsync(this);
        }

        public override async Task AgregarAsync()
        {
            foreach (var grupo in _grupos)
            {
                await _repositorioUsuarioLDAP.AgregarUsuarioAGrupoAsync(this, grupo);
            }
        }

        public override async Task SustraerAsync()
        {
            foreach (var grupo in _grupos)
            {
                await _repositorioUsuarioLDAP.BorrarUsuarioDeGrupoAsync(this, grupo);
            }
        }

        public void AddGrupo(Grupo grupo)
        {
            if (!_grupos.Contains(grupo))
            {
                _grupos.Add(grupo);
                grupo.AddUsuario(this);
            }
        }

        public void RemoveGrupo(Grupo grupo)
        {
            if (_grupos.Contains(grupo))
            {
                _grupos.Remove(grupo);
                grupo.RemoveUsuario(this);
            }
        }

        public bool PerteneceAGrupo(Grupo grupo)
        {
            return _grupos.Contains(grupo);
        }

        public string[] GetRutaRelativaSeparada()
        {
            return RutaRelativa?.Split('/') ?? [];
        }

        public string[] GetDominioSeparado()
        {
            return Dominio?.Split('.') ?? [];
        }

        public string GetNombrePrincipal()
        {
            return string.IsNullOrEmpty(UserOprid) ? null : $"{UserOprid}@{Dominio}";
        }

        public override bool IsAplicacionCritica()
        {
            return true;
        }

        public string GetDescripcion()
        {
            return SgaPuesto;
        }

        public string GetNombreAMostrar()
        {
            return string.IsNullOrWhiteSpace(PrefijoNombreAMostrar) ? GetNombreCompleto() : $"{PrefijoNombreAMostrar} {GetNombreCompleto()}";
        }

        public override bool Equals(object obj)
        {
            return obj is UsuarioLDAP usuario && Emplid == usuario.Emplid;
        }

        public override int GetHashCode()
        {
            return Emplid?.GetHashCode() ?? 0;
        }
    }
}
