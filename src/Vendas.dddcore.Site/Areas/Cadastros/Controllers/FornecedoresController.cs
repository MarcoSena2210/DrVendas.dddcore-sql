using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Vendas.dddcore.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class FornecedoresController : CadastroBaseController
    {
        private readonly IApplicationFornecedor appFornecedores;
        public readonly IApplicationShared appShared;


        public FornecedoresController(IApplicationFornecedor _appFornecedores
                                                         ,IApplicationShared _appShared)
        {
            appFornecedores  = _appFornecedores;
            appShared = _appShared;
        }

        #region LISTAGEM FORNECEDORES
        [Route("Cadastro-Fornecedores-Listagem")]
        public IActionResult Index()
        {
            ViewBag.RetornoPost = TempData["RetornoPost"];  //recebe do post do excluir
            return View();
        }

        public JsonResult ListagemFornecedoresJson()
        {
            var lista = appFornecedores.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }
        #endregion

        #region INCLUIR-CLIENTE
        [Route("Cadastro-Fornecedores-Incluir")]
        public IActionResult Incluir()
        {
            //ViewBag =forma de  passar dados para view
            ViewBag.ListaEstados = appShared.ObterEstados();
            return View();
        }

        [Route("Cadastro-Fornecedores-Incluir")]
        [HttpPost]
        public IActionResult Incluir(FornecedorViewModel model)
        {
            ViewBag.ListaEstados = appShared.ObterEstados();
            if (!ModelState.IsValid) return View();  //verifica se passou por todas validações  ou model
            var fornecedor = appFornecedores.Adicionar(model);
            ViewBag.RetornoPost = "success,Fornecedor incluído com sucesso!";
            if (VerificaErros(fornecedor.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível incluir o fornecedor!";
            }
            return View(model);
        }
        #endregion FIM-INCLUIR-CLIENTE

        #region ALTERAR-FORNECEDOR

        [Route("Cadastro-Fornecedores-Alterar")]
        public IActionResult Alterar(int id)
        {
            ViewBag.ListaEstados = appShared.ObterEstados();
            var model = appFornecedores.ObterPorId(id);
            return View(model);
        }

        [Route("Cadastro-Fornecedores-Alterar")]
        [HttpPost]
        public IActionResult Alterar(FornecedorViewModel model)
        {
            ViewBag.ListaEstados = appShared.ObterEstados();
            if (!ModelState.IsValid) return View();
            var fornecedor = appFornecedores.Atualizar(model);
            ViewBag.RetornoPost = "success,Fornecedor alterado com sucesso!";
            if (VerificaErros(fornecedor.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível alterar o fornecedor!";
            }
            return View(model);
        }
        #endregion FIM-ALTERAR-CLIENTE

        #region DETALHAR-FORNECEDOR
        [Route("Cadastro-Fornecedores-Detalhar")]
        public IActionResult Detalhar(int id)
        {
            var model = appFornecedores.ObterPorId(id);
            return View(model);
        }

        #endregion FIM-DETALHAR-CLIENTE

        #region EXCLUIR-FORNECEDOR
        [Route("Cadastro-Fornecedores-Excluir")]
        public IActionResult Excluir(int id)
        {
            var model = appFornecedores.ObterPorId(id);
            return View(model);
        }

        [Route("Cadastro-Fornecedores-Excluir")]
        [HttpPost]
        public IActionResult Excluir(FornecedorViewModel model)
        {
            // TempData, guarda a mensagem para ser exibido na pagina INDEX 
            //se houver 
            var fornecedor = appFornecedores.Remover(model);
            TempData["RetornoPost"] = "success,Fornecedor excluído com sucesso!";
            if (VerificaErros(fornecedor.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível excluir o fornecedor!";
                return View(model);
            }
            return RedirectToAction("Index");
        }
        #endregion FIM-EXCLUIR-FORNECEDOR

    }
}