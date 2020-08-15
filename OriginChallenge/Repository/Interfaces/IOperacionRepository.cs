using OriginChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Repository.Interfaces
{
    public interface IOperacionRepository: IRepository<Operacion>
    {
        IEnumerable<Operacion> GetByIdTarjeta(int idTarjeta);
    }
}
