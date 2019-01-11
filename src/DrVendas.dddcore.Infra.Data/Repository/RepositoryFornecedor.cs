using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DrVendas.dddcore.Infra.Data.Repository
{
    public class RepositoryFornecedor : Repository<Fornecedor>, IRepositoryFornecedor
    {
        public RepositoryFornecedor(ContextEFSQLServer MeuContexto)
            : base(MeuContexto)
        {

        }
        public Fornecedor ObterPorApelido(string apelido)
        {
            return Db.Fornecedor.AsNoTracking().FirstOrDefault(f => f.Apelido == apelido);
        }

        public Fornecedor ObterPorCpfCnpj(string cpfcnpj)
        {
            return Db.Fornecedor.AsNoTracking().FirstOrDefault(f => f.CPFCNPJ.Numero == cpfcnpj);
        }
    }
}
