using ProdutosApp.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Messages
{
    /// <summary>
    /// Interface para gravação dos dados do produto
    /// em um serviço de fila de mensageria
    /// </summary>
    public interface IMessageProducer
    {
        /// <summary>
        /// Método para gravação do log dos produtos
        /// </summary>
        void CreateLogProdutos(ProdutosLogDto dto);

        /// <summary>
        /// Método para gravação do log dos produtos
        /// </summary>
        void CreateLogFornecedores(FornecedoresLogDto dto);
    }
}
