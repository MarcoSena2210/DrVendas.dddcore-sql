using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Vendas.dddcore.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ClientesController : CadastroBaseController
    {

        /*Para usar o obter todos da camada de aplicação precisamos fazer a injeção de dependências
         * precisa instanciar todas as classe que precisamos, 
         * quem faz é o contanner de injecçao de dependencias tem varios
         * como inject, vamos usar o nativo do dotnet, na camada de cross cutting*/

        public readonly IApplicationCliente appClientes;
        public readonly IApplicationShared appShared;

        public ClientesController(IApplicationCliente _appClientes, IApplicationShared _appShared)
        {
            appClientes = _appClientes;
            appShared = _appShared;
        }


        #region Listar
        [Route("Cadastro-Clientes-Listagem")]
        public IActionResult Index()
        {
            ViewBag.RetornoPost = TempData["RetornoPost"];  //recebe do post 
            return View();
        }

        public JsonResult ListagemClientesJson()
        {
            var lista = appClientes.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }
        #endregion Listar
        
        #region  Incluir-Cliente
        [Route("Cadastro-Clientes-Incluir")]
        public IActionResult Incluir()
        {
            //ViewBag =forma de  passar dados para view
            ViewBag.ListaEstados = appShared.ObterEstados();
            return View();
        }

        [Route("Cadastro-Clientes-Incluir")]
        [HttpPost]
        public IActionResult Incluir(ClienteViewModel model)
        {
            ViewBag.ListaEstados = appShared.ObterEstados();
            if (!ModelState.IsValid) return View();  //verifica se passou por todas validações  ou model
            var cliente = appClientes.Adicionar(model);
            ViewBag.RetornoPost = "success,Cliente incluído com sucesso!";
            if (VerificaErros(cliente.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível incluir o cliente!";
            }
             return View(model);
        }
        #endregion FIM-Incluir-Cliente

        #region Alterar-Cliente

        [Route("Cadastro-Clientes-Alterar")]
        public IActionResult Alterar(int id)
        {
            ViewBag.ListaEstados = appShared.ObterEstados();
            var model = appClientes.ObterPorId(id);
            return View(model);
        }

        [Route("Cadastro-Clientes-Alterar")]
        [HttpPost]
        public IActionResult Alterar(ClienteViewModel model)
        {
            ViewBag.ListaEstados = appShared.ObterEstados();
            if (!ModelState.IsValid) return View();
            var cliente = appClientes.Atualizar(model);
            ViewBag.RetornoPost = "success,Cliente alerado com sucesso!";
            if (VerificaErros(cliente.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível alterar o cliente!";
            }
            return View(model);
        }
        #endregion FIM-Alterar-Cliente

        #region Detalhar-Cliente
        [Route("Cadastro-Clientes-Detalhar")]
        public IActionResult Detalhar(int id)
        {
            var model = appClientes.ObterPorId(id);
            return View(model);
        }
        #endregion FIM- Detalhar-Cliente

        #region  Excluir-Cliente
        [Route("Cadastro-Clientes-Excluir")]
        public IActionResult Excluir(int id)
        {
            var model = appClientes.ObterPorId(id);
            return View(model);
        }

        [Route("Cadastro-Clientes-Excluir")]
        [HttpPost]
        public IActionResult Excluir(ClienteViewModel model)
        {
            // TempData, guarda a mensagem para ser exibido na pagina INDEX 
            //se houver 
            var cliente = appClientes.Remover(model);
            TempData["RetornoPost"] = "success,Cliente excluído com sucesso!";
            if (VerificaErros(cliente.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível excluir o cliente!";
                return View(model);
            }
            return RedirectToAction("Index");
        }
        #endregion FIM-Excluir-Cliente

    }
}