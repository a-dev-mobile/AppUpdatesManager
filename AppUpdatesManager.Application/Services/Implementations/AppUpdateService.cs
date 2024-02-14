
using AppUpdatesManager.Application.Contracts;
using AppUpdatesManager.Application.DTOs;
using AppUpdatesManager.Application.Services.Contracts;
using AppUpdatesManager.Domain.Entities;
using AppUpdatesManager.Domain.Interfaces;
using AppUpdatesManager.Infrastructure.Entities;

namespace AppUpdatesManager.Application.Services.Implementations
{
    public class AppUpdateService : IAppUpdateService
    {
        private readonly IAppUpdateRepository _appUpdateRepository;

        public AppUpdateService(IAppUpdateRepository appUpdateRepository)
        {
            _appUpdateRepository = appUpdateRepository;
        }

        public async Task<bool> AddUpdateAsync(AppUpdateDto request)
        {
            // Преобразуйте DTO в сущность и добавьте в базу данных с помощью репозитория
            // Например:
            var domain = new ApplicationUpdate { Name = request.FileName, PackageName = "" };
            // return await _appUpdateRepository.AddAsync(entity);
            await Task.Delay(1000);
            return false;
        }


    }
}
