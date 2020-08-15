using OriginChallenge.Models;
using OriginChallenge.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Repository.Implementacion
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly OriginChallengeContext Context;

        public Repository(OriginChallengeContext context)
        {
            Context = context;
        }

        public void Add(T entidad)
        {
            Context.Set<T>().Add(entidad);
            Save();
        }

        public IEnumerable<T> Get()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Save()
        {
            
            using (var transaccion = Context.Database.BeginTransaction()) 
            {
                try
                {
                    Context.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                }
            }
            
            
        }

        public void Update(T entidad)
        {
            var a = Context.Set<T>().Attach(entidad);
            Save();
        }
    }
}
