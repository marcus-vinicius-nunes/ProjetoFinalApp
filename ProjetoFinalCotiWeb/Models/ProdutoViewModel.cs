using ProdutosApp.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinalCotiWeb.Models
{
    public class ProdutoViewModel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public int? FornecedorId { get; set; }
    }
}
