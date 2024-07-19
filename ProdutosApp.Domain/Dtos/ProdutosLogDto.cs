using ProdutosApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Dtos
{
    /// <summary>
    /// DTO para modelo de dados do log dos produtos
    /// </summary>
    public class ProdutosLogDto
    {
        public Guid? Id { get; set; }
        public DateTime? DataHora { get; set; }
        public TipoLog? Tipo { get; set; }
        public ProdutosResponseDto? Produto { get; set; }
    }

    public enum TipoLog
    {
        CREATE = 1,
        UPDATE = 2,
        DELETE = 3
    }
}
