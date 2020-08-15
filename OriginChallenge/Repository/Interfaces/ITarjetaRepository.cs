using OriginChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Repository.Interfaces
{
    public interface ITarjetaRepository: IRepository<Tarjeta>
    {
        Tarjeta GetByNumeroEncriptado(string numeroEncriptado);

        Tarjeta Loguear(string numeroEncriptado, string pinEncriptado);
    }
}
