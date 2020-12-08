using HcodeR.Core.Domain.Contracts.Repositories;
using HcodeR.Domain.Entities;
using HcodeR.Infrastructure.Pagination.Pagination;
using System;
using System.Threading.Tasks;

namespace HcodeR.Domain.Contracts.Repositories
{
    public interface IClienteRepository : IUnitOfWork
    {
        Task<PaginatedList<Cliente>> ListarClientesAsync(PaginationFilter paginationFilter);
        Task<Cliente> ObterClientePorIdAsync(Guid id);

        void AdicionarCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
        void ExcluirCliente(Cliente cliente);
    }
}
