namespace AppUpdatesManager.Application.Services.Contracts
{
    public interface IAppUpdateService
    {
        Task<bool> IsPackageExistsAsync(string packageName);
    }
}
