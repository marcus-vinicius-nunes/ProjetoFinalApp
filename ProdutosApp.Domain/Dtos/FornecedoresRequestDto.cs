using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Dtos
{
    public class FornecedoresRequestDto
    {
        [Required(ErrorMessage = "Por favor, informe o nome do fornecedor.")]
        public string? Nome { get; set; }
    }
}
