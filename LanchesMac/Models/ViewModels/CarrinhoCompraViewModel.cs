using LanchesMac.Models;
using System.Collections.Generic;

namespace LanchesMac.Models.ViewModels
{
    public class CarrinhoCompraViewModel
    {
        public CarrinhoCompra CarrinhoCompra { get; set; }
        public decimal CarrinhoCompraTotal { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }

        public CarrinhoCompraViewModel()
        {

        }

        public CarrinhoCompraViewModel(CarrinhoCompra carrinhoCompra, decimal carrinhoCompraTotal, IEnumerable<Categoria> categorias)
        {
            CarrinhoCompra = carrinhoCompra;
            CarrinhoCompraTotal = carrinhoCompraTotal;
            Categorias = categorias;
        }

        public CarrinhoCompraViewModel(CarrinhoCompra carrinhoCompra, decimal carrinhoCompraTotal)
        {
            CarrinhoCompra = carrinhoCompra;
            CarrinhoCompraTotal = carrinhoCompraTotal;
        }

        public CarrinhoCompraViewModel(CarrinhoCompra carrinhoCompra)
        {
            CarrinhoCompra = carrinhoCompra;           
        }
    }
}
