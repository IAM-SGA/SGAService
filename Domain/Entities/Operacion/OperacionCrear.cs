namespace Domain.Entities.Operacion
{
    public class OperacionCrear : OperacionUsuario
    {
        public override void Ejecutar()
        {
            usuario.CrearAsync();
        }
    }
}
