using LanchesMac.Models;
using System;
using System.Collections.Generic;
using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }
        IEnumerable<Lanche> ILancheRepository.Lanches => _context.Lanches.Include(ctor => ctor.Categoria);

        IEnumerable<Lanche> ILancheRepository.LanchesPreferidos => _context.Lanches.Where(l => l.IsLanchePreferido == true);

        Lanche ILancheRepository.GetLancheById(int LancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == LancheId);
        }
    }
}
