using Domain.Entities.Operacion;
using Domain.Enums.Novedades;
using Domain.Interfaces.Novedades;

namespace Domain.Entities.Novedades
{
    /// <summary>
    /// Representa una Novedad de un determinado usuario.
    /// </summary>
    [Serializable]
    public class Novedad
    {
        private readonly INovedadRepository _novedadRepository;

        // Constantes
        public static readonly EstadoNovedad APROBADO = EstadoNovedad.A;
        public static readonly EstadoNovedad PROCESANDO = EstadoNovedad.P;
        public static readonly EstadoNovedad ERROR = EstadoNovedad.R;
        private static readonly string USUARIO_UPDATE = ConfigurationManager.AppSettings["usuario_sga"];

        // Propiedades
        public string Legajo { get; set; }
        public long NumeroSolicitud { get; set; }
        public DateTime AddDttm { get; set; }
        public EstadoNovedad Estado { get; set; }
        public DateTime LastUpdateDttm { get; set; }
        public string OpridLastUpdate { get; set; }
        public List<OperacionUsuario> Operaciones { get; set; }
        public string Comando { get; set; }
        public long InstanciaProceso { get; set; }
        public string EmailText { get; set; }
        public string CreateIn { get; set; }
        public string LogonName { get; set; }
        public string SgaMail { get; set; }
        public string SgaMailExt { get; set; }

        public Novedad(INovedadRepository novedadRepository)
        {
            _novedadRepository = novedadRepository;
            Operaciones = new List<OperacionUsuario>();
        }

        public void AgregarOperacionUsuario(OperacionUsuario operacionUsuario)
        {
            Operaciones.Add(operacionUsuario);
        }

        public async Task ProcesarAsync()
        {            
            // Modifico el estado a procesada
            Estado = PROCESANDO;
            LastUpdateDttm = DateTime.Now;
            OpridLastUpdate = USUARIO_UPDATE;
            await _novedadRepository.ActualizarAsync(this);

            bool error = false;

            // Proceso las operaciones
            foreach (var operacion in Operaciones)
            {
                try
                {
                    await operacion.Ejecutar();
                }
                catch (Exception ex)
                {
                    error = true;
                    if (operacion.EsCritica()) break;
                }
            }

            if (error)
            {
                // Marco la novedad con error
                Estado = ERROR;
                LastUpdateDttm = DateTime.Now;
                OpridLastUpdate = USUARIO_UPDATE;
                await _novedadRepository.ActualizarAsync(this);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is not Novedad nov) return false;
            return Legajo.Equals(nov.Legajo) && NumeroSolicitud.Equals(nov.NumeroSolicitud);
        }
    }
}
