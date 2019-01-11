using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DrVendas.dddcore.Infra.Data.Repository
{
    public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        //No construtor precisamos injetar o contexto , repassamos para o "pai"... :base(MeuContexto) 
        public RepositoryCliente(ContextEFSQLServer MeuContexto)
            :base(MeuContexto) 
        {

        }

        public Cliente ObterPorApelido(string apelido)
        {
            return Db.Cliente.AsNoTracking().FirstOrDefault(c => c.Apelido == apelido);
           
        }

        public Cliente ObterPorCpfCnpj(string cpfcnpj)
        {
            return Db.Cliente.AsNoTracking().FirstOrDefault(c => c.CPFCNPJ.Numero == cpfcnpj);

        }
    }
}
