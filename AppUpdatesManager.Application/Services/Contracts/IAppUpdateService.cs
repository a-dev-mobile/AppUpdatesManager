
using AppUpdatesManager.Application.Contracts;
using AppUpdatesManager.Application.DTOs;

namespace AppUpdatesManager.Application.Services.Contracts
{
    public interface IAppUpdateService
    {

        Task<bool> AddUpdateAsync(AppUpdateDto request);





    }
}
