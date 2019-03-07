using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Vendas.dddcore.Site.Areas.Pedidos.Controllers
{
    public class PedidoBaseController : Controller
    {
        public bool VerificaErros(List<string> Erros)
        {
            if (Erros.Any())
            {
                ViewBag.ListaErros = Erros;  //erros que veio da verifica erros
                return true;
            }
            return false;
        }

    }
}