using System;

namespace APIPrueba.Entities
{
    public class SendMail
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string CiudadYEstado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
