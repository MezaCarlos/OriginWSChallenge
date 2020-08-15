using System;
using System.Collections.Generic;

namespace OriginChallenge.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Tarjeta = new HashSet<Tarjeta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }

        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
