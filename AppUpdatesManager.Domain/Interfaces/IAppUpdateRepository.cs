namespace AppUpdatesManager.Domain.Interfaces

{
    public interface IAppUpdateRepository
    {

        Task<bool> IsPackageExistsAsync(string packageName);


    }
}
