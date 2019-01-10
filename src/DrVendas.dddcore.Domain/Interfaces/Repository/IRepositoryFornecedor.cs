using DrVendas.dddcore.Domain.Entidades;

namespace DrVendas.dddcore.Domain.Interfaces.Repository
{
   public interface IRepositoryFornecedor : IRepository<Fornecedor>
    {
        //Apenas os metodos especifícos, pois os demais são herdados do IRepository
        Fornecedor ObterPorCpfCnpj(string cpfcnpj);
        Fornecedor ObterPorApelido(string apelido);
    }
}
