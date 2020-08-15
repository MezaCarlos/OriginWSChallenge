using OriginChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.ModelsExtend
{
    public class OperacionRetiro: Operacion
    {
        public OperacionRetiro():base()
        {

        }
        public OperacionRetiro(Tarjeta tarjeta, eEstadoOperacion estado) : base(tarjeta, estado)
        {
            IdTipoOperacion = Convert.ToInt32(eTipoOperacion.Retiro);
            Codigo = "RET" + tarjeta.Id + Fecha.ToString("yyyyMMddHHmmsss");
        }
    }
}
