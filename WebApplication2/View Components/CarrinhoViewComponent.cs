using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.View_Components
{
    [ViewComponent (Name="carrinho")]
    public class CarrinhoViewComponent:ViewComponent
    {
        public int ItensCarrinho { get; set; }
        public CarrinhoViewComponent()
        {
            ItensCarrinho = 3;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(ItensCarrinho);
        }
    }
}
