using AutoMapper;
using HcodeR.Application.Contracts;
using HcodeR.Application.Dtos.Base;
using HcodeR.Application.Dtos.Command;
using HcodeR.Application.Dtos.Pagination;
using HcodeR.Application.Dtos.Query;
using HcodeR.Core.Domain.Validations;
using HcodeR.Crosscutting.Validations;
using HcodeR.Domain.Contracts.Repositories;
using HcodeR.Domain.Contracts.Services;
using HcodeR.Domain.Entities;
using HcodeR.Infrastructure.Pagination.Pagination;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HcodeR.Application.Services
{
    public class ClienteAppService : CustomValidation, IClienteAppService
    {
        private readonly ILogger<ClienteAppService> _logger;
        private readonly IClienteService _clienteService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteAppService(
            ILogger<ClienteAppService> logger,
            IClienteService clienteService,
            IClienteRepository clienteRepository,
            IMapper mapper)
        {
            _logger = logger;
            _clienteService = clienteService;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedListDto<ClienteQueryDto>> ListarClientesAsync(PaginationFilterDto paginationFilterDto)
        {
            return _mapper.Map<PaginatedListDto<ClienteQueryDto>>(await _clienteRepository.ListarClientesAsync(_mapper.Map<PaginationFilter>(paginationFilterDto)));
        }

        public async Task<ClienteQueryDto> ObterClientePorIdAsync(Guid id)
        {
            return _mapper.Map<ClienteQueryDto>(await _clienteRepository.ObterClientePorIdAsync(id));
        }

        public async Task<List<Notification>> AdicionarClienteAsync(ClienteCommandDto clienteDto)
        {
            return await _clienteService.AdicionarClienteAsync(_mapper.Map<Cliente>(clienteDto));
        }

        public async Task<List<Notification>> AtualizarClienteAsync(Guid id, ClienteCommandDto clienteDto)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(id);

            if (cliente == null)
            {                
                AddNotification(CodeNotification.Application, Message.NotExist("Cliente"));

                _logger.LogError(Message.NotExist("Cliente"));

                return _notifications;
            }

            return await _clienteService.AtualizarClienteAsync(_mapper.Map(clienteDto, cliente));
        }

        public async Task<List<Notification>> ExcluirClienteAsync(Guid id)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(id);

            if (cliente == null)
            {
                AddNotification(CodeNotification.Application, Message.NotExist("Cliente"));

                _logger.LogError(Message.NotExist("Cliente"));

                return _notifications;
            }

            return await _clienteService.ExcluirClienteAsync(cliente);
        }       
    }
}
