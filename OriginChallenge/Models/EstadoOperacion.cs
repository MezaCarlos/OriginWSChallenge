using System;
using System.Collections.Generic;

namespace OriginChallenge.Models
{
    public partial class EstadoOperacion
    {
        public EstadoOperacion()
        {
            Operacion = new HashSet<Operacion>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Operacion> Operacion { get; set; }
    }
}
