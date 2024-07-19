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
    public class FornecedorDomainService : IFornecedorDomainService
    {
        private readonly IFornecedorRepository _FornecedorRepository;
        private readonly IMapper _mapper;
        private readonly IMessageProducer _messageProducer;

        public FornecedorDomainService(IFornecedorRepository FornecedorRepository, IMapper mapper, IMessageProducer messageProducer)
        {
            _FornecedorRepository = FornecedorRepository;
            _mapper = mapper;
            _messageProducer = messageProducer;
        }

        public FornecedoresResponseDto Add(FornecedoresRequestDto request)
        {
            var fornecedor = _mapper.Map<Fornecedor>(request);
            _FornecedorRepository.Add(fornecedor);

            fornecedor = _FornecedorRepository.GetById(fornecedor.Id);

            var response = _mapper.Map<FornecedoresResponseDto>(fornecedor);

            GravarLog(TipoLog.CREATE, response);

            return response;
        }

        public FornecedoresResponseDto Update(int id, FornecedoresRequestDto request)
        {
            var fornecedor = _FornecedorRepository.GetById(id);

            fornecedor.Nome = request.Nome;

            _FornecedorRepository.Update(fornecedor);

            var response = _mapper.Map<FornecedoresResponseDto>(fornecedor);

            GravarLog(TipoLog.UPDATE, response);

            return response;
        }

        public FornecedoresResponseDto Delete(int id)
        {
            var fornecedor = _FornecedorRepository.GetById(id);
            _FornecedorRepository.Delete(fornecedor);

            var response = _mapper.Map<FornecedoresResponseDto>(fornecedor);

            GravarLog(TipoLog.DELETE, response);

            return response;
        }

        public List<FornecedoresResponseDto> GetAll()
        {
            return _mapper.Map<List<FornecedoresResponseDto>>(_FornecedorRepository.GetAll());
        }

        public FornecedoresResponseDto? GetById(int id)
        {
            return _mapper.Map<FornecedoresResponseDto>(_FornecedorRepository.GetById(id));
        }

        private void GravarLog(TipoLog tipo, FornecedoresResponseDto response)
        {
            var fornecedorLogDto = new FornecedoresLogDto
            {
                Id = Guid.NewGuid(),
                DataHora = DateTime.Now,
                Tipo = tipo,
                Fornecedor = response
            };

            _messageProducer.CreateLogFornecedores(fornecedorLogDto);
        }

        public void Dispose()
        {
            _FornecedorRepository.Dispose();
        }
    }
}
