namespace AppUpdatesManager.Domain.Entities
{
    public class ApplicationUpdate
    {

        public required string Name { get; set; }
        public required string PackageName { get; set; }
        // public required ICollection<DownloadDetail> DownloadDetails { get; set; }
    }
}
