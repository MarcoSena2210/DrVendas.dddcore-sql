using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace Vendas.dddcore.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ProdutosController : CadastroBaseController
    {
        private readonly IApplicationProduto appProdutos;
        private readonly IApplicationFornecedor appFornecedores;

        public ProdutosController(IApplicationProduto _appProdutos,
                                  IApplicationFornecedor _appFornecedores)
        {
            appProdutos = _appProdutos;
            appFornecedores = _appFornecedores;
        }
        #region Listar

        [Route("Cadastro-Produtos-Listagem")]
        public IActionResult Index()
        {
            ViewBag.RetornoPost = TempData["RetornoPost"];
            return View();
        }

        public JsonResult ListagemProdutosJson()
        {
            var lista = appProdutos.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }
        #endregion Listar

        #region Incluir 
        [Route("Cadastro-Produtos-Incluir")]
        public IActionResult Incluir()
        {   
            //Usada para preecher a combo fornecedor
            ViewBag.ListaFornecedores = new SelectList(appFornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            return View();
        }

        [HttpPost]
        [Route("Cadastro-Produtos-Incluir")]
        public IActionResult Incluir(ProdutoViewModel model, IFormFile fileSelect)
        {
            /* 
             *  Recebemos a ProdutoViewModel e o arquivo selecionado atraves fileSelect que é do tipo   IFormFile
             *  filtramos os tipos que desejamos 
            */


            ViewBag.ListaFornecedores = new SelectList(appFornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            if (!ModelState.IsValid) return View();

            if (fileSelect != null && !string.IsNullOrEmpty(fileSelect.FileName))
            {
                string extension = Path.GetExtension(fileSelect.FileName).ToUpper();
                if (extension == ".JPG" || extension == ".PNG" || extension == ".BMP")
                {
                    MemoryStream ms = new MemoryStream();
                    fileSelect.OpenReadStream().CopyTo(ms);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    model.Foto = ms.ToArray();
                }
            }
         #endregion Incluir

        #region Adicionar
            var produto = appProdutos.Adicionar(model);
            ViewBag.RetornoPost = "success,Produto incluído com sucesso!";
            if (VerificaErros(produto.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível incluir o produto!";
            }
            return View(model);
        }
        #endregion Adicionar

        #region Alterar 
        [Route("Cadastro-Produtos-Alterar")]
        public IActionResult Alterar(int id)
        {
            ViewBag.ListaFornecedores = new SelectList(appFornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            var model = appProdutos.ObterPorId(id);
            return View(model);
        }

        [HttpPost]
        [Route("Cadastro-Produtos-Alterar")]
        public IActionResult Alterar(ProdutoViewModel model, IFormFile fileSelect)
        {
            ViewBag.ListaFornecedores = new SelectList(appFornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            if (!ModelState.IsValid) return View();

            if (fileSelect != null && !string.IsNullOrEmpty(fileSelect.FileName))
            {
                string extension = Path.GetExtension(fileSelect.FileName).ToUpper();
                if (extension == ".JPG" || extension == ".PNG" || extension == ".BMP")
                {
                    MemoryStream ms = new MemoryStream();
                    fileSelect.OpenReadStream().CopyTo(ms);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    model.Foto = ms.ToArray();
                }
            }

            var produto = appProdutos.Atualizar(model);
            ViewBag.RetornoPost = "success,Produto alterado com sucesso!";
            if (VerificaErros(produto.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível alterar o produto!";
            }
            return View(model);
        }
        #endregion Alterar

        #region Detalhar
        [Route("Cadastro-Produtos-Detalhar")]
        public IActionResult Detalhar(int id)
        {
            ViewBag.ListaFornecedores = new SelectList(appFornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            var model = appProdutos.ObterPorId(id);
            return View(model);
        }

        #endregion  Detalhar

        #region Excluir
        [Route("Cadastro-Produtos-Excluir")]
        public IActionResult Excluir(int id)
        {
            ViewBag.ListaFornecedores = new SelectList(appFornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            var model = appProdutos.ObterPorId(id);
            return View(model);
        }

        [HttpPost]
        [Route("Cadastro-Produtos-Excluir")]
        public IActionResult Excluir(ProdutoViewModel model)
        {
            var produtos = appProdutos.Remover(model);
            TempData["RetornoPost"] = "success,Produto excluído com sucesso!";
            if (VerificaErros(produtos.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível excluir o produto!";
                return View(model);
            }
            return RedirectToAction("Index");
        }

        #endregion Excluir

        public IActionResult GetFoto(int id)
        {
            var model = appProdutos.ObterPorId(id);
            Stream stream = new MemoryStream(model.Foto);
            return new FileStreamResult(stream, MediaTypeNames.Image.Jpeg);
        }


    }
}