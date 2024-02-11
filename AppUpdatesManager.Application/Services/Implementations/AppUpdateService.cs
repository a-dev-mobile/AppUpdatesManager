using AppUpdatesManager.Application.Services.Contracts;
using AppUpdatesManager.Domain.Interfaces;

namespace AppUpdatesManager.Application.Services.Implementations
{
    public class AppUpdateService : IAppUpdateService
    {
        private readonly IAppUpdateRepository _appUpdateRepository;

        public AppUpdateService(IAppUpdateRepository appUpdateRepository)
        {
            _appUpdateRepository = appUpdateRepository;
        }

        public async Task<bool> IsPackageExistsAsync(string packageName)
        {
            return await _appUpdateRepository.IsPackageExistsAsync(packageName);
        }
    }
}
