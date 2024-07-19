using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Dtos
{
    /// <summary>
    /// DTO para modelo de dados do log dos fornecedores
    /// </summary>
    public class FornecedoresLogDto
    {
        public Guid? Id { get; set; }
        public DateTime? DataHora { get; set; }
        public TipoLog? Tipo { get; set; }
        public FornecedoresResponseDto? Fornecedor { get; set; }
    }
}
