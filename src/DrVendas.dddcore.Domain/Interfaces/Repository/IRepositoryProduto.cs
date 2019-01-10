using DrVendas.dddcore.Domain.Entidades;

namespace DrVendas.dddcore.Domain.Interfaces.Repository
{
    public interface IRepositoryProduto : IRepository<Produto>
    {
        //Apenas os metodos especifícos, pois os demais são herdados do IRepository
        Produto ObterPorNome(string nome);
        Produto ObterPorApelido(string apelido);
    }
}
