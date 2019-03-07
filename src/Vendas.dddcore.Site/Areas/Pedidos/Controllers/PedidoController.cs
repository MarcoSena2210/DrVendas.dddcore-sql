using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.Interfaces.AgregracaoPedidos;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Application.AppVendas.ViewModels.AgregracaoPedidos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Vendas.dddcore.Site.Areas.Pedidos.Controllers
{
    [Area("Pedidos")]
    public class PedidoController : PedidoBaseController
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
            ViewBag.ListaClientes = new SelectList(appClientes.ObterTodos(), "Id", "Nome", "-- Selecione --");
            ViewBag.ListaProdutos = new SelectList(appProdutos.ObterTodos(), "Id", "Nome", "-- Selecione --");

            return View();
        }

        
        [Route("Pedido-Cadastro-Incluir")]
        [HttpPost]
        public IActionResult Incluir(PedidoViewModel model)
        {

            ViewBag.ListaClientes = new SelectList(appClientes.ObterTodos(), "Id", "Nome", "-- Selecione --");
            ViewBag.ListaProdutos = new SelectList(appProdutos.ObterTodos(), "Id", "Nome", "-- Selecione --");


            if (!ModelState.IsValid) return View();  //verifica se passou por todas validações  ou model
            var pedido = appPedidos.Adicionar(model);
            ViewBag.RetornoPost = "success,Fornecedor incluído com sucesso!";

            if (VerificaErros(pedido.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível incluir o fornecedor!";
                return View(model);
            }

            TempData["RetornoPost "] = ViewBag.RetornoPost;
            return  RedirectToAction ("Index");
          
        }


        #endregion  Incluir
    }
}