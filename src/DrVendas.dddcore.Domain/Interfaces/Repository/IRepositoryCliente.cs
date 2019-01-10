using DrVendas.dddcore.Domain.Entidades;

namespace DrVendas.dddcore.Domain.Interfaces.Repository
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        //Apenas os metodos especifícos, pois os demais são herdados do IRepository 
        Cliente ObterPorCpfCnpj(string cpfcnpj);
        Cliente ObterPorApelido(string apelido);
    }
}
