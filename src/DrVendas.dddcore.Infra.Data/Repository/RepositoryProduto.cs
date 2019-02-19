using Dapper;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Aqui estamos fazendos as consultas com DAPPER
//

namespace DrVendas.dddcore.Infra.Data.Repository
{
    public class RepositoryProduto : Repository<Produto>, IRepositoryProduto
    {
        public RepositoryProduto( ContextEFSQLServer MeuContexto)
            :base(MeuContexto)
        {
         }
        public override IEnumerable<Produto> ObterTodos()
        {
            // vamos usar  o linq
            var results = from p in Db.Produto
                          join f in Db.Fornecedor on p.FornecedorId equals f.Id
                          select new Produto
                          {
                              Id = p.Id,
                              Apelido = p.Apelido,
                              Nome = p.Nome,
                              Valor = p.Valor,
                              Unidade = p.Unidade,
                              Fornecedor = new Fornecedor {
                                  Nome = f.Nome
                              }
                          };
            return results.ToList();
            //   Nao vamos mais usar o dapper aqui e sim o linq
            //StringBuilder query = new StringBuilder();
            //query.Append(@" SELECT * FROM produto ORDER BY ID DESC");
            //var produtos = Db.Database.GetDbConnection().Query<Produto>(query.ToString());  
            //return produtos;
        }

        public override Produto ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produto  WHERE id = @uID  ");
            var produtos = Db.Database.GetDbConnection().Query<Produto>(query.ToString(),new { uID = id });
            return produtos.FirstOrDefault();
        }

        public Produto ObterPorApelido(string apelido)
        {
            // return Db.Produtos.AsNoTracking().FirstOrDefault(p => p.Apelido == apelido);
            // inner join com fornecedor
            // return Db.Produtos.Include(f => f.Fornecedor).FirstOrDefault(p => p.Apelido == apelido);
            StringBuilder query = new StringBuilder();   //vamos usar o dapper
            query.Append(@" SELECT * FROM produto  WHERE apelido = @uAPELIDO");
            var produtos = Db.Database.GetDbConnection().Query<Produto>(query.ToString(), new { uAPELIDO = apelido });
            return produtos.FirstOrDefault();
        }

        public Produto ObterPorNome(string nome)
        {
            // return Db.Produtos.AsNoTracking().FirstOrDefault(p => p.Nome == nome);
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produto WHERE nome = @uNOME  ");
            var produtos = Db.Database.GetDbConnection().Query<Produto>(query.ToString(), new { uNOME = nome });
            return produtos.FirstOrDefault();
        }
    }
}