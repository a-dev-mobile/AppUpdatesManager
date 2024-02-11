namespace AppUpdatesManager.Domain.Entities;


public class AppVersionDetails
{
    public int VersionCode { get; set; }
    public required string VersionName { get; set; }
    public required string Checksum { get; set; }
    public long FileSizeBytes { get; set; }
    public string? UpdateDescription { get; set; }
}
