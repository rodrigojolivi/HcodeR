using HcodeR.Application.Dtos.Query;
using HcodeR.Application.Dtos.Base;
using HcodeR.Application.Dtos.Command;
using HcodeR.Application.Dtos.Pagination;
using HcodeR.Crosscutting.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HcodeR.Application.Contracts
{
    public interface IClienteAppService
    {
        Task<PaginatedListDto<ClienteQueryDto>> ListarClientesAsync(PaginationFilterDto paginationFilterDto);
        Task<ClienteQueryDto> ObterClientePorIdAsync(Guid id);

        Task<List<Notification>> AdicionarClienteAsync(ClienteCommandDto clienteDto);
        Task<List<Notification>> AtualizarClienteAsync(Guid id, ClienteCommandDto clienteDto);
        Task<List<Notification>> ExcluirClienteAsync(Guid id);
    }
}
