using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.Interfaces.AgregracaoPedidos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Vendas.dddcore.Site.Areas.Pedidos.Controllers
{
    [Area("Pedidos")]
    public class PedidoController : Controller
    {

        #region Injeção de Dependências
        private readonly IApplicationPedido appPedidos;
        private readonly IApplicationCliente appClientes;
        private readonly IApplicationProduto appProdutos;
        
        public PedidoController(IApplicationPedido _appPedidos, 
                                                   IApplicationCliente _appClientes, 
                                                   IApplicationProduto _appProdutos)
        {
            appPedidos = _appPedidos;
            appClientes = _appClientes;
            appProdutos = _appProdutos;
         }

        #endregion Injeção de Dependências

        #region Listar
        [Route("Pedido-Cadastro-Listagem")]
        public IActionResult Index()
        {
            ViewBag.RetornoPost = TempData["RetornoPost"];  //recebe do post 
            return View();
        }
      
        public JsonResult ListagemPedidosJson()
        {
            var lista = appPedidos.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }

        #endregion Listar

        #region Incluir
        [Route("Pedido-Cadastro-Incluir")]
        public IActionResult Incluir()
        {
         //   ViewBag.RetornoPost = TempData["RetornoPost"];  //recebe do post 
             //Usada para preecher a combo fornecedor
            ViewBag.ListaClientess = new SelectList(appClientes.ObterTodos(), "Id", "Nome", "-- Selecione --");
            ViewBag.ListaClientess = new SelectList(appProdutos.ObterTodos(), "Id", "Nome", "-- Selecione --");
            return View();
        }
        #endregion  Incluir
    }
}