using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrVendas.dddcore.Application.AppVendas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Vendas.dddcore.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ProdutosController : CadastroBaseController
    {
        private readonly IApplicationProduto appprodutos;

        public ProdutosController(IApplicationProduto _appprodutos)
        {
            appprodutos = _appprodutos;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListagemProdutosJson()
        {
            var lista = appprodutos.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }


    }
}