using System.Threading.Tasks;

namespace HcodeR.Core.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
