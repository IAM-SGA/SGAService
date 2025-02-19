namespace Domain.Entities.Operacion
{
    public class OperacionSustraer : OperacionUsuario
    {
        public override void Ejecutar()
        {
            usuario.SustraerAsync();
        }
    }
}
