using Dapper;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrVendas.dddcore.Infra.Data.Repository
{
    public class RepositoryFornecedor : Repository<Fornecedor>, IRepositoryFornecedor
    {
        public RepositoryFornecedor(ContextEFSQLServer MeuContexto)
            : base(MeuContexto)
        {

        }
        public override IEnumerable<Fornecedor> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedor ORDER BY id DESC");
            return Db.Database.GetDbConnection().Query<Fornecedor>(query.ToString());
        }

        public override Fornecedor ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedor WHERE id=@uID");
            var retorno = Db.Database.GetDbConnection().Query<Fornecedor>(query.ToString(), new { uID = id }).FirstOrDefault();
            return retorno;
        }

        public Fornecedor ObterPorApelido(string apelido)
        {
            // return Db.Fornecedores.AsNoTracking().FirstOrDefault(f => f.Apelido == apelido);
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedor WHERE apelido=@uAPELIDO");
            var retorno = Db.Database.GetDbConnection().Query<Fornecedor>(query.ToString(), new { uAPELIDO = apelido }).FirstOrDefault();
            return retorno;
        }

        public Fornecedor ObterPorCpfCnpj(string cpfcnpj)
        {
            // return Db.Fornecedores.AsNoTracking().FirstOrDefault(f => f.CPFCNPJ.Numero == cpfcnpj);
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedor WHERE CpfCnpj=@uCPFCNPJ");
            var retorno = Db.Database.GetDbConnection().Query<Fornecedor>(query.ToString(), new { uCPFCNPJ = cpfcnpj }).FirstOrDefault();
            return retorno;
        }

    }
}