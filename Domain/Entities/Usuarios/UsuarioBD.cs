using Domain.Interfaces.Usuarios;

namespace Domain.Entities.Usuarios
{
    public class UsuarioBD : Usuario
    {
        private List<string> consultas;
        private string sga_perfil;
        private string sga_dbase;

        private readonly IUsuarioBDRepository _usuarioBDRepository;

        public UsuarioBD(IUsuarioBDRepository usuarioBDRepository)
        {
            _usuarioBDRepository = usuarioBDRepository ?? throw new ArgumentNullException(nameof(usuarioBDRepository));
            consultas = new List<string>();
        }

        private async Task EjecutarAsync()
        {
            await _usuarioBDRepository.EjecutarAsync(consultas, this, this.SgaApplId);
        }

        public override async Task CrearAsync()
        {
            await EjecutarAsync();
        }

        public override async Task ActualizarAsync()
        {
            await EjecutarAsync();
        }

        public override async Task EliminarAsync()
        {
            await EjecutarAsync();
        }

        public override async Task AgregarAsync()
        {
            await EjecutarAsync();
        }

        public override async Task SustraerAsync()
        {
            await EjecutarAsync();
        }

        public void AgregarConsulta(string consulta)
        {
            consultas.Add(consulta);
        }

        public IReadOnlyList<string> GetConsultas()
        {
            return consultas.AsReadOnly();
        }

        public string SgaPerfil
        {
            get => sga_perfil;
            set => sga_perfil = value;
        }

        public string SgaDbase
        {
            get => sga_dbase;
            set => sga_dbase = value;
        }

        public override bool IsAplicacionCritica()
        {
            throw new NotImplementedException();
        }
    }
}
