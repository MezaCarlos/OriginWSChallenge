using System;
using System.Collections.Generic;

namespace OriginChallenge.Models
{
    public partial class Operacion
    {
        public int Id { get; set; }
        public int IdTarjeta { get; set; }
        public int IdTipoOperacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Codigo { get; set; }
        public decimal Monto { get; set; }
        public int Estado { get; set; }

        public virtual EstadoOperacion EstadoNavigation { get; set; }
        public virtual Tarjeta IdTarjetaNavigation { get; set; }
        public virtual TipoOperacion IdTipoOperacionNavigation { get; set; }
    }
}
