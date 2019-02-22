using DrVendas.dddcore.Application.Shared.Interfaces;
using DrVendas.dddcore.Domain.Shared.ValueObjects;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;


namespace DrVendas.dddcore.Application.Shared.Services
{
   
        public class ApplicationShared : IApplicationShared
        {

            public SelectList ObterEstados()
            {
                UfVO uf = new UfVO();
                var estados = uf.ObterEstados();
                var ret = new SelectList(estados, "Codigo", "Codigo", "BA");
                return ret;
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

        }
  
}
