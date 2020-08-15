using System;
using System.Collections.Generic;

namespace OriginChallenge.Models
{
    public partial class Tarjeta
    {
        public Tarjeta()
        {
            Operacion = new HashSet<Operacion>();
        }

        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string NumeroCifrado { get; set; }
        public string Numero { get; set; }
        public string PinCifrado { get; set; }
        public int Pin { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Saldo { get; set; }
        public int Estado { get; set; }

        public virtual EstadoTarjeta EstadoNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Operacion> Operacion { get; set; }
    }
}
