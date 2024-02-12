namespace AppUpdatesManager.Domain.Interfaces

{
    public interface IAppUpdateRepository
    {

        bool IsPackageExists(string packageName);


    }
}
