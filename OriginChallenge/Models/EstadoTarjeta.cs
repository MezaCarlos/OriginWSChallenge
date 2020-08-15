using System;
using System.Collections.Generic;

namespace OriginChallenge.Models
{
    public partial class EstadoTarjeta
    {
        public EstadoTarjeta()
        {
            Tarjeta = new HashSet<Tarjeta>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
