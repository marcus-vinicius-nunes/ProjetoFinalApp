using ProdutosApp.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Services
{
    public interface IFornecedorDomainService : IDisposable
    {
        FornecedoresResponseDto Add(FornecedoresRequestDto request);
        FornecedoresResponseDto Update(int id, FornecedoresRequestDto request);
        FornecedoresResponseDto Delete(int id);

        List<FornecedoresResponseDto> GetAll();
        FornecedoresResponseDto? GetById(int id);
    }
}
