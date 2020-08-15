using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Models
{
    public enum eEstadoOperacion
    {
        OK=1,
        Error = 2
    }

    public enum eEstadoTarjeta
    {
        Habilitada = 1,
        Bloqueada = 2
    }

    public enum eTipoOperacion
    {
        Balance = 1,
        Retiro = 2
    }


}
