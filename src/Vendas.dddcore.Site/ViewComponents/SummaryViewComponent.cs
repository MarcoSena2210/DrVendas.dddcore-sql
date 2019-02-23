

using Microsoft.AspNetCore.Mvc;

namespace Vendas.dddcore.Site.ViewComponents
{ 
    public class SummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (ViewBag.ListaErros != null)
            {

                foreach (var item in ViewBag.ListaErros)
                {
                    ViewData.ModelState.AddModelError(string.Empty, item);
                }
            }
            return View();
        }

    }
}
