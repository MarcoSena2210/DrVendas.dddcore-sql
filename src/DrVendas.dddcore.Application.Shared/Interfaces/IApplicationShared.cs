using Microsoft.AspNetCore.Mvc.Rendering;
using System;


namespace DrVendas.dddcore.Application.Shared.Interfaces
{
    public interface IApplicationShared : IDisposable
    {
        SelectList ObterEstados();
    }
}
