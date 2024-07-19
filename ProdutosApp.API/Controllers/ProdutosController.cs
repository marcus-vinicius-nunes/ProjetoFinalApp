using Microsoft.AspNetCore.Http;
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
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoDomainService _produtoDomainService;

        public ProdutosController(IProdutoDomainService produtoDomainService)
        {
            _produtoDomainService = produtoDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdutosResponseDto), 201)]
        public IActionResult Post([FromBody] ProdutosRequestDto request)
        {
            return StatusCode(201, _produtoDomainService.Add(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProdutosResponseDto), 200)]
        public IActionResult Put(int id, [FromBody] ProdutosRequestDto request)
        {
            return StatusCode(200, _produtoDomainService.Update(id, request));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutosResponseDto), 200)]
        public IActionResult Delete(int id)
        {
            return StatusCode(200, _produtoDomainService.Delete(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosResponseDto>), 200)]
        public IActionResult Get()
        {
            return StatusCode(200, _produtoDomainService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosResponseDto), 200)]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _produtoDomainService.GetById(id));
        }

        [HttpPost("cadastrarProduto")]
        public IActionResult CadastrarProduto([FromBody] ProdutoViewModel model)
        {

            var response = new ProdutosRequestDto
            {
                Nome = model.Nome,
                Preco = model.Preco,
                Quantidade = model.Quantidade,
                FornecedorId = model.FornecedorId,
            };

            return StatusCode(201, _produtoDomainService.Add(response));
        }

        [HttpGet("consultaProduto/{id}")]
        public IActionResult ConsultaProduto(int id)
        {
            var fornecedor = _produtoDomainService.GetById(id);

            if (fornecedor != null)
            {
                return StatusCode(200, _produtoDomainService.GetById(id));
            }

            return NotFound(new ErrorViewModel { Message = "Produto não encontrado." });
        }

        [HttpPut("atualizaProduto/{id}")]
        public async Task<IActionResult> AtualizaProduto(int id, [FromBody] ProdutoViewModel model)
        {
            var response = new ProdutosRequestDto
            {
                Nome = model.Nome,
                Preco = model.Preco,
                Quantidade = model.Quantidade,
                FornecedorId = model.FornecedorId
            };

            return StatusCode(200, _produtoDomainService.Update(id, response));
        }
    }
}
