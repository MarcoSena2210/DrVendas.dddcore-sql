using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Domain.Shared.Entidades;
using DrVendas.dddcore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DrVendas.dddcore.Infra.Data.Repository
{
    public class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : EntidadeBase
    {
        protected ContextEFSQLServer Db;
        protected DbSet<TEntidade> DbSet;

        public Repository(ContextEFSQLServer MeuContexto)
        {
                 Db = MeuContexto;
        }

        public virtual  void Adicionar(TEntidade obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntidade obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remover(TEntidade obj)
        {
           DbSet.Remove(obj);
        }

        public virtual IEnumerable<TEntidade> ObterTodos()
        {
            return DbSet.ToList();
        }


        public virtual TEntidade ObterPorId(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public  IEnumerable<TEntidade> Buscar(Expression<Func<TEntidade, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }


        public void Dispose()
        {
           Db.Dispose();
        }

    }
}
