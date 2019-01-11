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
    public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        //No construtor precisamos injetar o contexto , repassamos para o "pai"... :base(MeuContexto) 
        public RepositoryCliente(ContextEFSQLServer MeuContexto)
            :base(MeuContexto) 
        {

        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes ORDER BY id DESC");
            return Db.Database.GetDbConnection().Query<Cliente>(query.ToString());
        }

        public override Cliente ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes WHERE id=@uID");
            var retorno = Db.Database.GetDbConnection().Query<Cliente>(query.ToString(), new { uID = id }).FirstOrDefault();
            return retorno;
        }

        public Cliente ObterPorApelido(string apelido)
        {
            // return Db.Clientes.AsNoTracking().FirstOrDefault(c => c.Apelido == apelido);
            // FOI susbstuido as consultas pelo dapper pq a performace é melhor
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes WHERE apelido=@uAPELIDO");
            var retorno = Db.Database.GetDbConnection().Query<Cliente>(query.ToString(), new { uAPELIDO = apelido }).FirstOrDefault();
            return retorno;
        }

        public Cliente ObterPorCpfCnpj(string cpfcnpj)
        {
            // return Db.Clientes.AsNoTracking().FirstOrDefault(c => c.CPFCNPJ.Numero == cpfcnpj);
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes WHERE CpfCnpj=@uCPFCNPJ");
            var retorno = Db.Database.GetDbConnection().Query<Cliente>(query.ToString(), new { uCPFCNPJ = cpfcnpj }).FirstOrDefault();
            return retorno;
        }
    }
}