namespace Domain.Entities.Operacion
{
    public class OperacionAgregar : OperacionUsuario
    {
        public override void Ejecutar()
        {
            usuario.AgregarAsync();
        }
    }
}
