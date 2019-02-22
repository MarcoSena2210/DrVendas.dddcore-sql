using System.Collections.Generic;

namespace DrVendas.dddcore.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit(List<string> erros); 
    }
}
