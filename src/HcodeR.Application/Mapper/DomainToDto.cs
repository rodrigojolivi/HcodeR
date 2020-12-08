using AutoMapper;
using HcodeR.Application.Dtos.Base;
using HcodeR.Application.Dtos.Command;
using HcodeR.Application.Dtos.Query;
using HcodeR.Domain.Entities;
using HcodeR.Infrastructure.Pagination.Pagination;

namespace HcodeR.Application.Mapper
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            #region Cliente

            CreateMap<Cliente, ClienteQueryDto>();

            CreateMap<PaginatedList<Cliente>, PaginatedListDto<ClienteQueryDto>>();

            #endregion
        }
    }
}
