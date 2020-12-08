using HcodeR.Application.Contracts;
using HcodeR.Application.Dtos.Base;
using HcodeR.Application.Dtos.Command;
using HcodeR.Application.Dtos.Pagination;
using HcodeR.Application.Dtos.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HcodeR.API.Controllers.v1
{
    [Route("api/v1/clientes")]
    public class ClienteController : CustomController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        /// <summary>
        /// Lista as clientes com filtro e paginação
        /// </summary>
        /// <param name="paginationFilterDto"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedListDto<ClienteQueryDto>), 200)]
        public async Task<IActionResult> ListarClientes([FromQuery] PaginationFilterDto paginationFilterDto)
        {
            return Response(codeResponse: CodeResponse.Get, data: await _clienteAppService.ListarClientesAsync(paginationFilterDto));
        }

        /// <summary>
        /// Obtém a cliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ClienteQueryDto), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> ObterClientePorId([FromRoute] Guid id)
        {
            return Response(codeResponse: CodeResponse.Find, data: await _clienteAppService.ObterClientePorIdAsync(id));
        }

        /// <summary>
        /// Adiciona uma cliente
        /// </summary>
        /// <param name="clienteDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AdicionarCliente([FromBody] ClienteCommandDto clienteDto)
        {
            if (!ModelState.IsValid) return Response(ModelState);

            return Response(codeResponse: CodeResponse.Post, notifications: await _clienteAppService.AdicionarClienteAsync(clienteDto));
        }

        /// <summary>
        /// Atualiza uma cliente
        /// </summary>
        /// <param name="clienteDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> AtualizarCliente([FromRoute] Guid id, [FromBody] ClienteCommandDto clienteDto)
        {
            if (!ModelState.IsValid) return Response(ModelState);

            return Response(codeResponse: CodeResponse.Put, notifications: await _clienteAppService.AtualizarClienteAsync(id, clienteDto));
        }

        /// <summary>
        /// Exclui uma cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> ExcluirCliente([FromRoute] Guid id)
        {
            return Response(codeResponse: CodeResponse.Delete, notifications: await _clienteAppService.ExcluirClienteAsync(id));
        }
    }
}
