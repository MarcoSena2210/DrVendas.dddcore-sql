using DrVendas.dddcore.Domain.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DrVendas.dddcore.Domain.Interfaces.Repository
{
    public interface IRepository<TEntidade> :IDisposable where TEntidade : EntidadeBase 
    {
        void Adicionar(TEntidade obj);
        void Atualizar(TEntidade obj);
        void Remover(TEntidade obj);
        TEntidade ObterPorId(int id);
        IEnumerable<TEntidade> ObterTodos();
        IEnumerable<TEntidade> Buscar(Expression<Func<TEntidade, bool>> predicate);
    }
}
