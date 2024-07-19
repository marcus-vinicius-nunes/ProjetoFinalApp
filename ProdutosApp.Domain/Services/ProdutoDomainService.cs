using AutoMapper;
using ProdutosApp.Domain.Dtos;
using ProdutosApp.Domain.Interfaces.Messages;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;
using ProdutosApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Services
{
    public class ProdutoDomainService : IProdutoDomainService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IMessageProducer _messageProducer;

        public ProdutoDomainService(IProdutoRepository produtoRepository, IMapper mapper, IMessageProducer messageProducer)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _messageProducer = messageProducer;
        }

        public ProdutosResponseDto Add(ProdutosRequestDto request)
        {
            var produto = _mapper.Map<Produto>(request);
            _produtoRepository.Add(produto);

            produto = _produtoRepository.GetById(produto.Id);   

            var response = _mapper.Map<ProdutosResponseDto>(produto);

            GravarLog(TipoLog.CREATE, response);

            return response;
        }

        public ProdutosResponseDto Update(int id, ProdutosRequestDto request)
        {
            var produto = _produtoRepository.GetById(id);

            produto.Nome = request.Nome;
            produto.Preco = request.Preco;
            produto.Quantidade = request.Quantidade;
            produto.FornecedorId = request.FornecedorId;

            _produtoRepository.Update(produto);

            var response = _mapper.Map<ProdutosResponseDto>(produto);

            GravarLog(TipoLog.UPDATE, response);

            return response;
        }

        public ProdutosResponseDto Delete(int id)
        {
            var produto = _produtoRepository.GetById(id);
            _produtoRepository.Delete(produto);

            var response = _mapper.Map<ProdutosResponseDto>(produto);

            GravarLog(TipoLog.DELETE, response);

            return response;
        }

        public List<ProdutosResponseDto> GetAll()
        {
            return _mapper.Map<List<ProdutosResponseDto>>(_produtoRepository.GetAll());
        }

        public ProdutosResponseDto? GetById(int id)
        {
            return _mapper.Map<ProdutosResponseDto>(_produtoRepository.GetById(id));
        }

        private void GravarLog(TipoLog tipo, ProdutosResponseDto response)
        {
            var produtoLogDto = new ProdutosLogDto
            {
                Id = Guid.NewGuid(),
                DataHora = DateTime.Now,
                Tipo = tipo,
                Produto = response
            };

            _messageProducer.CreateLogProdutos(produtoLogDto);
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
