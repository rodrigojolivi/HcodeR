using HcodeR.Crosscutting.Validations;
using HcodeR.Domain.Contracts.Repositories;
using HcodeR.Domain.Contracts.Services;
using HcodeR.Domain.Entities;
using HcodeR.Core.Domain.Validations;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HcodeR.Domain.Services
{
    public class ClienteService : CustomValidation, IClienteService
    {
        private readonly ILogger<ClienteService> _logger;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(
            ILogger<ClienteService> logger,
            IClienteRepository clienteRepository)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Notification>> AdicionarClienteAsync(Cliente cliente)
        {
            _clienteRepository.AdicionarCliente(cliente);

            await _clienteRepository.CommitAsync();

            _logger.LogInformation(Message.RegistrationSuccessfullyComplete, cliente);

            return _notifications;
        }

        public async Task<List<Notification>> AtualizarClienteAsync(Cliente cliente)
        {
            _clienteRepository.AtualizarCliente(cliente);

            await _clienteRepository.CommitAsync();

            _logger.LogInformation(Message.RecordUpdatedSuccessfully, cliente);

            return _notifications;
        }

        public async Task<List<Notification>> ExcluirClienteAsync(Cliente cliente)
        {
            _clienteRepository.ExcluirCliente(cliente);

            await _clienteRepository.CommitAsync();

            _logger.LogInformation(Message.RecordDeletedSuccessfully, cliente);

            return _notifications;
        }
    }
}
