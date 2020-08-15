
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Models
{
    public partial class Operacion
    {
        public Operacion()
        {

        }
        public Operacion(Tarjeta tarjeta, eEstadoOperacion estado)
        {
            Estado = Convert.ToInt32(estado);
            Fecha = DateTime.Now;
            IdTarjeta = tarjeta.Id;
            Monto = tarjeta.Saldo;
        }

        public eEstadoOperacion EstadoEnum 
        { 
            get { return (eEstadoOperacion)this.Estado; } 
        }

        public eTipoOperacion TipoEnum
        {
            get { return (eTipoOperacion)this.IdTipoOperacion; }
        }

    }
}
