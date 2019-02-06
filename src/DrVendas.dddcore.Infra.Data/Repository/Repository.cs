using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Domain.Shared.Entidades;
using DrVendas.dddcore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
                 DbSet = Db.Set<TEntidade>(); //inicia o dbset
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

        //Para trabalhar com ADO, faz a conexao
        protected string ObterStringConexao()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").
                Build();
            return config.GetConnectionString("DefaultConnection");
        }


        public void Dispose()
        {
           Db.Dispose();
        }

    }
}
