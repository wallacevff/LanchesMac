using LanchesMac.Models;
using LanchesMac.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LanchesMac.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            List<CarrinhoCompraItem> itens = _carrinhoCompra.GetCarrinhoCompraItens();

            // List<CarrinhoCompraItem> itens = new List<CarrinhoCompraItem>() { new CarrinhoCompraItem(), new CarrinhoCompraItem() };
            _carrinhoCompra.CarrinhoCompraItens = itens;

            CarrinhoCompraViewModel carrinhoCompraVM = new CarrinhoCompraViewModel(_carrinhoCompra, _carrinhoCompra.GetCarrinhoCompraTotal());
            return View(carrinhoCompraVM);
        }
    }

}
