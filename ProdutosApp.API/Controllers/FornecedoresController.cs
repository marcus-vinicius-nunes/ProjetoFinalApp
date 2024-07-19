using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Domain.Dtos;
using ProdutosApp.Domain.Interfaces.Services;
using ProdutosApp.Domain.Models;
using ProdutosApp.Domain.Services;
using ProjetoFinalCotiWeb.Models;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorDomainService _FornecedorDomainService;

        public FornecedoresController(IFornecedorDomainService FornecedorDomainService)
        {
            _FornecedorDomainService = FornecedorDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(FornecedoresResponseDto), 201)]
        public IActionResult Post([FromBody] FornecedoresRequestDto request)
        {
            return StatusCode(201, _FornecedorDomainService.Add(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FornecedoresResponseDto), 200)]
        public IActionResult Put(int id, [FromBody] FornecedoresRequestDto request)
        {
            return StatusCode(200, _FornecedorDomainService.Update(id, request));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FornecedoresResponseDto), 200)]
        public IActionResult Delete(int id)
        {
            return StatusCode(200, _FornecedorDomainService.Delete(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<FornecedoresResponseDto>), 200)]
        public IActionResult Get()
        {
            return StatusCode(200, _FornecedorDomainService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FornecedoresResponseDto), 200)]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _FornecedorDomainService.GetById(id));
        }

        [HttpPost("cadastrarFornecedor")]
        public IActionResult CadastrarFornecedor([FromBody] FornecedorViewModel model)
        {

            var response = new FornecedoresRequestDto
            {
                Nome = model.Nome,
            };

            return StatusCode(201, _FornecedorDomainService.Add(response));
        }

        [HttpGet("consultaFornecedor/{id}")]
        public IActionResult ConsultaFornecedor(int id)
        {
            var fornecedor = _FornecedorDomainService.GetById(id);

            if (fornecedor != null)
            {
                return StatusCode(200, _FornecedorDomainService.GetById(id));
            }

            return NotFound(new ErrorViewModel { Message = "Fornecedor não encontrado." });
        }

        [HttpPut("atualizaFornecedor/{id}")]
        public async Task<IActionResult> AtualizaFornecedor(int id, [FromBody] FornecedorViewModel model)
        {
            var response = new FornecedoresRequestDto
            {
                Nome = model.Nome,
            };

            return StatusCode(200, _FornecedorDomainService.Update(id, response));
        }
    }
}
