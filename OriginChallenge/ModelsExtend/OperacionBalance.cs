using OriginChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Models
{
    public class OperacionBalance : Operacion
    {
        public OperacionBalance():base()
        {

        }
        public OperacionBalance(Tarjeta tarjeta, eEstadoOperacion estado):base(tarjeta,estado)
        {
            IdTipoOperacion = Convert.ToInt32(eTipoOperacion.Balance);
            Codigo = "BAL" + tarjeta.Id + Fecha.ToString("yyyyMMddHHmmsss");
        }
    }
}
