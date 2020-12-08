using AutoMapper;
using HcodeR.Application.Dtos.Command;
using HcodeR.Application.Dtos.Pagination;
using HcodeR.Domain.Entities;
using HcodeR.Infrastructure.Pagination.Pagination;

namespace HcodeR.Application.Mapper
{
    public class DtoToDomain : Profile
    {
        public DtoToDomain()
        {
            CreateMap<ClienteCommandDto, Cliente>()
                .ForMember(x => x.CreatedAt, x => x.Ignore());

            CreateMap<PaginationFilterDto, PaginationFilter>();
        }
    }
}
