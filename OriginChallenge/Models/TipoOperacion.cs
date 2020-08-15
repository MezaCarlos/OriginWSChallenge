using System;
using System.Collections.Generic;

namespace OriginChallenge.Models
{
    public partial class TipoOperacion
    {
        public TipoOperacion()
        {
            Operacion = new HashSet<Operacion>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Operacion> Operacion { get; set; }
    }
}
