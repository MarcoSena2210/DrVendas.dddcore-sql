using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Vendas.dddcore.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ClientesController : Controller
    {
        /*Para usar o obter todos da camada de aplicação precisamos fazer a injeção de dependências
         * precisa instanciar todas as classe que precisamos, quem faz é o contanner de injecçao de dependencias tem varios
         * como inject, vamos usar o nativo do dotnet, na camada de cross cutting*/

        public readonly IApplicationCliente appClientes;

        public readonly IApplicationShared appShared;

        public ClientesController(IApplicationCliente _appClientes, IApplicationShared _appShared)
        {
            appClientes = _appClientes;
            appShared = _appShared;
        }

        public IActionResult Index()
        {
                    return View();
        }

        public IActionResult Incluir()
        {
            //ViewBag =forma de  passar dados para view
            ViewBag.ListaEstados = appShared.ObterEstados();
            return View();
        }

        [HttpPost]
        public IActionResult Incluir(ClienteViewModel model)
        {

            ViewBag.ListaEstados = appShared.ObterEstados();
            if (!ModelState.IsValid) return View();  //verifica se passou por todas validações  ou model
            var cliente = appClientes.Adicionar(model);
            return View(model);
        }


        public JsonResult ListagemClientesJson()
        {
            var lista = appClientes.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }
    }
}