using HcodeR.Crosscutting.Validations;
using HcodeR.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HcodeR.Domain.Contracts.Services
{
    public interface IClienteService
    {
        Task<List<Notification>> AdicionarClienteAsync(Cliente cliente);
        Task<List<Notification>> AtualizarClienteAsync(Cliente cliente);
        Task<List<Notification>> ExcluirClienteAsync(Cliente cliente);
    }
}
