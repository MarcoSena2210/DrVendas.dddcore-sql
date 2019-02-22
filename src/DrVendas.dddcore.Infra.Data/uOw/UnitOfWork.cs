using DrVendas.dddcore.Infra.Data.Context;
using DrVendas.dddcore.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrVendas.dddcore.Infra.Data.uOw
{
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextEFSQLServer context;

        public UnitOfWork(ContextEFSQLServer _context)
        {
            context = _context;
        }

        public void Commit(List<string> erros)
        {
            context.SaveChanges();
        }
    }
}
