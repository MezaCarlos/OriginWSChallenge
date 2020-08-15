using OriginChallenge.Models;
using OriginChallenge.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Repository.Implementacion
{
    public class TarjetaRepository : Repository<Tarjeta>, ITarjetaRepository
    {

        public TarjetaRepository(OriginChallengeContext context)
            :base(context)
        {
        }

        public Tarjeta GetByNumeroEncriptado(string numeroEncriptado)
        {
            return Context.Tarjeta.Where(x => x.NumeroCifrado == numeroEncriptado).FirstOrDefault();
        }

        public Tarjeta Loguear(string numeroEncriptado, string pinEncriptado)
        {
            return Context.Tarjeta.Where(x => x.NumeroCifrado == numeroEncriptado && x.PinCifrado == pinEncriptado).FirstOrDefault();
        }
    }
}
