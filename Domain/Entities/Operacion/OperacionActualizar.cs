namespace Domain.Entities.Operacion
{
    public class OperacionActualizar : OperacionUsuario
    {
        public override void Ejecutar()
        {
            usuario.ActualizarAsync();
        }
    }
}
