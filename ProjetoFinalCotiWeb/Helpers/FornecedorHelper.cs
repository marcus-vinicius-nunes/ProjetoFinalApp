using Blazored.LocalStorage;
using ProdutosApp.Domain.Dtos;

namespace ProjetoFinalCotiWeb.Helpers
{
    /// <summary>
    /// Classe para execucao de operações do sistema com o fornecedor
    /// </summary>
    public class FornecedorHelper
    {
        private readonly ILocalStorageService _storageService;

        public FornecedorHelper(ILocalStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task SignIn(FornecedoresResponseDto dto)
        {
            await _storageService.SetItemAsync("user-auth", dto);
        }
    }
}
