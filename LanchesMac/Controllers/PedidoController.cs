using LanchesMac.Models;
using LanchesMac.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMac.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            
            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, inclua um lanche...");
            }

            if (ModelState.IsValid)
            {
                _pedidoRepository.CriarPedido(pedido);
                /*
                TempData["Cliente"] = pedido.Nome;
                TempData["NumeroPedido"] = pedido.PedidoId;
                TempData["DataPedido"] = pedido.PedidoEnviado; */
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo pedido :) ";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();
                
                _carrinhoCompra.LimparCarrinho();

                return View("/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }

            return View(pedido);
        }
        /*
        public IActionResult CheckoutCompleto()
        {
            ViewBag.Cliente = TempData["Cliente"];
            ViewBag.NumeroPedido = TempData["NumeroPedido"];
            ViewBag.DataPedido = TempData["DataPedido"];
            ViewBag.TotalPedido = TempData["TotalPedido"];
            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo pedido :) ";
            return View();
        }
        */
    }
}
