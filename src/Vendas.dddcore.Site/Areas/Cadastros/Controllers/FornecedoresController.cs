using DrVendas.dddcore.Application.AppVendas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Vendas.dddcore.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class FornecedoresController : Controller
    {
        private readonly IApplicationFornecedor appfornecedor;

        public FornecedoresController(IApplicationFornecedor _appfornecedor)
        {
            appfornecedor = _appfornecedor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListagemFornecedoresJson()
        {
            var lista = appfornecedor.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }


    }
}