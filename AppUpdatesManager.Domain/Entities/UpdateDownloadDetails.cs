namespace AppUpdatesManager.Domain.Entities;

public class UpdateDownloadDetails
{
    public string? Url { get; set; }
    public AppVersionDetails? LatestVersionDetails { get; set; }
    public required UpdatePolicies UpdatePolicies { get; set; }
}
