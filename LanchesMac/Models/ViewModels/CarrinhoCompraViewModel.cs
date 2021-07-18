using LanchesMac.Models;

namespace LanchesMac.Models.ViewModels
{
    public class CarrinhoCompraViewModel
    {
        public CarrinhoCompra CarrinhoCompra { get; set; }
        public decimal CarrinhoCompraTotal { get; set; }

        public CarrinhoCompraViewModel()
        {

        }

        public CarrinhoCompraViewModel(CarrinhoCompra carrinhoCompra, decimal carrinhoCompraTotal)
        {
            CarrinhoCompra = carrinhoCompra;
            CarrinhoCompraTotal = carrinhoCompraTotal;
        }
    }
}
