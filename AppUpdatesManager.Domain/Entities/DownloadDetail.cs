namespace AppUpdatesManager.Domain.Entities
{
    public class DownloadDetail
    {
        public int DownloadDetailId { get; set; }
        public required string DownloadUrl { get; set; }
        public required SoftwareVersion CurrentVersion { get; set; }
        public required UpdateRequirement RequiredUpdate { get; set; }
    }
}
