using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entidad);

        T GetById(int id);

        IEnumerable<T> Get();

        void Save();

        void Update(T entidad);

    }
}
