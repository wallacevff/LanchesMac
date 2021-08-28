using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanchesMac.Repositories;
using LanchesMac.Models;
using LanchesMac.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace LanchesMac.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;
        private readonly ICategoriaRepository _categoria;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra, ICategoriaRepository categoria)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
            _categoria = categoria;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;
            IEnumerable<Categoria> categorias = _categoria.Categorias;

            var carrinhoCompraViewModel = new CarrinhoCompraViewModel(
                _carrinhoCompra, _carrinhoCompra.GetCarrinhoCompraTotal(), categorias);
            return View(carrinhoCompraViewModel);
        }

        [Authorize]
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            var lancheselecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if (lancheselecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheselecionado);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public RedirectToActionResult RemoverItemNoCarrinhoCompra(int lancheId)
        {
            var lancheselecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if (lancheselecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheselecionado);
            }
            return RedirectToAction("Index");
        }

    }
}
