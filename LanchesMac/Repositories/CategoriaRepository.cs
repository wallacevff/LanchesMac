using LanchesMac.Context;
using LanchesMac.Models;
using System;
using System.Collections.Generic;

namespace LanchesMac.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        IEnumerable<Categoria> ICategoriaRepository.Categorias => throw new NotImplementedException();
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
