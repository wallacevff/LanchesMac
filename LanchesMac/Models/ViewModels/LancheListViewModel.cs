using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesMac.Models;

namespace LanchesMac.Models.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }

        public LancheListViewModel()
        {

        }

        public LancheListViewModel(IEnumerable<Lanche> lanches, string categoriaAtual)
        {
            Lanches = lanches;
            CategoriaAtual = categoriaAtual;
        }
    }
   

}
