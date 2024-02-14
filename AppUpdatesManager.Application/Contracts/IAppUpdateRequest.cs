// В слое Application
namespace AppUpdatesManager.Application.Contracts
{
    public interface IAppUpdateRequest
    {
        byte[] FileContent { get; }
        string FileName { get; }
        string Checksum { get; }
        string? UpdateDescription { get; }
    }
}
