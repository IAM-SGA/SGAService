namespace Domain.Entities.Operacion
{
    public class OperacionEliminar : OperacionUsuario
    {
        public override void Ejecutar()
        {
            usuario.EliminarAsync();
        }
    }
}
