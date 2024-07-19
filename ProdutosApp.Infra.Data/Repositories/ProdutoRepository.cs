using Microsoft.EntityFrameworkCore;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Models;
using ProdutosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly DataContext _dataContext;

        public ProdutoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override List<Produto> GetAll()
        {
            return _dataContext.Set<Produto>()
                    .Include(p => p.Fornecedor)
                    .OrderBy(p => p.Nome)
                    .ToList();
        }

        public override Produto? GetById(int id)
        {
            return _dataContext.Set<Produto>()
                .Include(p => p.Fornecedor)
                .FirstOrDefault(p => p.Id == id);
        }

    }
}
