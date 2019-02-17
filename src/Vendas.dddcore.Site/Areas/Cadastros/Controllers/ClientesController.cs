using DrVendas.dddcore.Application.AppVendas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Vendas.dddcore.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ClientesController : Controller
    {
        /*Para usar o obter todos da camada de aplicação precisamos fazer a injeção de dependências
         * precisa instanciar todas as classe que precisamos, quem faz é o contanner de injecçao de dependencias tem varios
         * como inject, vamos usar o nativo do dotnet, na camada de cross cutting*/

        public readonly IApplicationCliente appClientes;
        public ClientesController(IApplicationCliente _appClientes)
        {
            appClientes = _appClientes;
        }
        public IActionResult Index()
        {
            var model = appClientes.ObterTodos();
            return View(model);
        }
    }
}