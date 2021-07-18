using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMac.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
        public HomeViewModel()
        {

        }

        public HomeViewModel(IEnumerable<Lanche> lanchesPreferidos)
        {
            LanchesPreferidos = lanchesPreferidos;
        }
    }
}
