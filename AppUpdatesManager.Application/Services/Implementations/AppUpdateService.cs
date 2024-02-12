using AppUpdatesManager.Application.Services.Contracts;
using AppUpdatesManager.Domain.Interfaces;

namespace AppUpdatesManager.Application.Services.Implementations
{
    public class AppUpdateService 
    {
        private readonly IAppUpdateRepository _appUpdateRepository;

        public AppUpdateService(IAppUpdateRepository appUpdateRepository)
        {
            _appUpdateRepository = appUpdateRepository;
        }

        public  bool IsPackageExistsAsync(string packageName)
        {
            return  true;
        }
    }
}
