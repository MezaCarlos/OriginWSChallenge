
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Models
{
    public partial class Tarjeta
    {
        public eEstadoTarjeta EstadoEnum
        {
            get { return (eEstadoTarjeta)this.Estado; }
        }
    }
}
