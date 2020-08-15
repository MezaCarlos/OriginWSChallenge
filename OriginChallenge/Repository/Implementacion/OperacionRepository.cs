using OriginChallenge.Models;
using OriginChallenge.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Repository.Implementacion
{
    public class OperacionRepository : Repository<Operacion>, IOperacionRepository
    {
        public OperacionRepository(OriginChallengeContext context) : 
            base(context)
        {
        }

        public IEnumerable<Operacion> GetByIdTarjeta(int idTarjeta)
        {
            return Context.Operacion.Where(x => x.IdTarjeta == idTarjeta).ToList();
        }
    }
}
