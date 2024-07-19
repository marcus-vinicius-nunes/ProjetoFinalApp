using ProdutosApp.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Services
{
    public interface IProdutoDomainService : IDisposable
    {
        ProdutosResponseDto Add(ProdutosRequestDto request);
        ProdutosResponseDto Update(int id, ProdutosRequestDto request);
        ProdutosResponseDto Delete(int id);

        List<ProdutosResponseDto> GetAll();
        ProdutosResponseDto? GetById(int id);
    }
}
