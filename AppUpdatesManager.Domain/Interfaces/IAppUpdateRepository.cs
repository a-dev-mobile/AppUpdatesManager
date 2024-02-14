
using AppUpdatesManager.Domain.Entities;

namespace AppUpdatesManager.Domain.Interfaces

{
    public interface IAppUpdateRepository
    {

        Task<bool> AddUpdateAsync(ApplicationUpdate modelDomain);


    }
}
