using DrVendas.dddcore.Application.AppVendas.Interfaces.AgregracaoPedidos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Vendas.dddcore.Site.Areas.Pedidos.Controllers
{
    [Area("Pedidos")]
    public class PedidoController : Controller
    {
        private readonly IApplicationPedido apppedidos;

        public PedidoController(IApplicationPedido _apppedidos)
        {
            apppedidos = _apppedidos;
         }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListagemPedidosJson()
        {
            var lista = apppedidos.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }
    }
}