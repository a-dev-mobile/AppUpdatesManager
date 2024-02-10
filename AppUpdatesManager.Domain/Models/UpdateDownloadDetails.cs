namespace AppUpdatesManager.Domain.Models;

public class UpdateDownloadDetails
{
    public string? Url { get; set; }
    public ApplicationVersionDetails? LatestVersionDetails { get; set; }
    public required UpdatePolicies UpdatePolicies { get; set; }
}
