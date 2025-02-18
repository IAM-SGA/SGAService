using System.Runtime.Serialization;

namespace Domain.Entities.Usuarios
{
    [Serializable]
    public abstract class Usuario : ISerializable
    {
        // Los nombres de las propiedades deben coincidir con las columnas de la Base de Datos
        protected string Emplid { get; set; } // Legajo
        protected string Name1 { get; set; }
        protected string Name2 { get; set; }
        protected string LastName { get; set; }
        protected string LastName2 { get; set; }
        protected string CotCuit { get; set; }
        protected string CotNroDoc { get; set; }
        protected string Deptid { get; set; }
        protected string SgaPuesto { get; set; }
        protected string SgaApplId { get; set; }
        protected string UserOprid { get; set; } // Usuario de Red
        protected string EmailText { get; set; }
        protected string CreateIn { get; set; }
        protected string LogonName { get; set; }
        protected string SgaMail { get; set; }
        protected string SgaMailExt { get; set; }

        // Métodos abstractos
        public abstract Task CrearAsync();
        public abstract Task ActualizarAsync();
        public abstract Task EliminarAsync();
        public abstract Task AgregarAsync();
        public abstract Task SustraerAsync();

        // Indica si la aplicación a la cual pertenece el usuario es crítica.
        public abstract bool IsAplicacionCritica();

        // Métodos públicos
        public string GetNombres()
        {
            if (string.IsNullOrWhiteSpace(Name2))
                return Name1;
            return $"{Name1} {Name2}";
        }

        public string GetApellidos()
        {
            if (string.IsNullOrWhiteSpace(LastName2))
                return LastName;
            return $"{LastName} {LastName2}";
        }

        public string GetNombreCompleto()
        {
            if (GetNombres() == null)
                return GetApellidos();
            if (GetApellidos() == null)
                return GetNombres();
            return $"{GetApellidos()} {GetNombres()}";
        }

        // Implementación de ISerializable
        protected Usuario()
        {
        }

        protected Usuario(SerializationInfo info, StreamingContext context)
        {
            Emplid = info.GetString(nameof(Emplid));
            Name1 = info.GetString(nameof(Name1));
            Name2 = info.GetString(nameof(Name2));
            LastName = info.GetString(nameof(LastName));
            LastName2 = info.GetString(nameof(LastName2));
            CotCuit = info.GetString(nameof(CotCuit));
            CotNroDoc = info.GetString(nameof(CotNroDoc));
            Deptid = info.GetString(nameof(Deptid));
            SgaPuesto = info.GetString(nameof(SgaPuesto));
            SgaApplId = info.GetString(nameof(SgaApplId));
            UserOprid = info.GetString(nameof(UserOprid));
            EmailText = info.GetString(nameof(EmailText));
            CreateIn = info.GetString(nameof(CreateIn));
            LogonName = info.GetString(nameof(LogonName));
            SgaMail = info.GetString(nameof(SgaMail));
            SgaMailExt = info.GetString(nameof(SgaMailExt));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Emplid), Emplid);
            info.AddValue(nameof(Name1), Name1);
            info.AddValue(nameof(Name2), Name2);
            info.AddValue(nameof(LastName), LastName);
            info.AddValue(nameof(LastName2), LastName2);
            info.AddValue(nameof(CotCuit), CotCuit);
            info.AddValue(nameof(CotNroDoc), CotNroDoc);
            info.AddValue(nameof(Deptid), Deptid);
            info.AddValue(nameof(SgaPuesto), SgaPuesto);
            info.AddValue(nameof(SgaApplId), SgaApplId);
            info.AddValue(nameof(UserOprid), UserOprid);
            info.AddValue(nameof(EmailText), EmailText);
            info.AddValue(nameof(CreateIn), CreateIn);
            info.AddValue(nameof(LogonName), LogonName);
            info.AddValue(nameof(SgaMail), SgaMail);
            info.AddValue(nameof(SgaMailExt), SgaMailExt);
        }
    }
