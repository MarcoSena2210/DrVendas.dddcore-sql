using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DrVendas.dddcore.Infra.Data.Repository
{
    public class RepositoryProduto : Repository<Produto>, IRepositoryProduto
    {
        public RepositoryProduto( ContextEFSQLServer MeuContexto)
            :base(MeuContexto)
        {
         }

        public Produto ObterPorApelido(string apelido)
        {
            return Db.Produto.AsNoTracking().FirstOrDefault(p => p.Apelido == apelido);
        }

        public Produto ObterPorNome(string nome)
        {
            return Db.Produto.AsNoTracking().FirstOrDefault(p => p.Nome == nome);
        }
    }
}