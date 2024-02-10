namespace AppUpdatesManager.Domain.Models;



public class ApplicationUpdate
{
    public required string DisplayName { get; set; }
    public required string PackageName { get; set; }
    public Dictionary<string, UpdateDownloadDetails>? StoreDownloads { get; set; }
}
