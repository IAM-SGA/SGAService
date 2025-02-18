namespace Domain.Interfaces.Usuarios
{
    public interface IUsuarioBDRepository
    {
        //Ejecuta las consultas en la aplicación dada, tomando los valores de las variables del objeto datos.
        Task EjecutarAsync(List<string> consultas, object datos, string idAplicacion);
    }
}
