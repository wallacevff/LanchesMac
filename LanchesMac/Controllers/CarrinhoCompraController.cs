﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanchesMac.Repositories;
using LanchesMac.Models;
using LanchesMac.Models.ViewModels;

namespace LanchesMac.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraViewModel = new CarrinhoCompraViewModel(
                _carrinhoCompra, _carrinhoCompra.GetCarrinhoCompraTotal());
            return View(carrinhoCompraViewModel);
        }

        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            var lancheselecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if (lancheselecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheselecionado);
            }
            return RedirectToAction("Index");
        }

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
