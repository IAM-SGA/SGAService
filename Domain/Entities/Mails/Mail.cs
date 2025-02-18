using Domain.Entities.Usuarios;

namespace Domain.Entities.Mails
{
    public class Mail
    {
        public string Path { get; set; }
        public string Servidor { get; set; }
        public bool? MailInternoActivo { get; set; }
        public bool? MailExternoActivo { get; set; }
        public string MailAddress { get; set; }
        public string MaxSendSize { get; set; }
        public string MaxReceiveSize { get; set; }
        public string RetentionPolicy { get; set; }
        public UsuarioLDAP Usuario { get; set; }

        public Mail() { }

        public string GetEmailExterno()
        {
            if (MailExternoActivo != true) return null;
            return $"{MailAddress}@coto.com.ar";
        }

        public string GetEmailInterno()
        {
            if (MailInternoActivo != true) return null;
            return $"{MailAddress}@{Usuario?.Dominio}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not Mail otherMail) return false;
            return string.Equals(MailAddress, otherMail.MailAddress, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return MailAddress?.GetHashCode() ?? 0;
        }
    }
}
